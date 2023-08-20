﻿using fNbt;
using MinecraftNbtWorld.Converters;
using MinecraftNbtWorld.Enums;
using MinecraftNbtWorld.Level;
using MinecraftNbtWorldViewer.Classes;
using MinecraftNbtWorldViewer.Classes.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftNbtWorld
{
    public class MWorld
    {
        public string Path { get; private set; }

        public string GetLevelDatPath()
        {
            return Path + "\\level.dat";
        }

        public MWorld(string WorldPath)
        {
            Path = WorldPath;
            LoadWorld();
        }

        void LoadWorld()
        {
            //Load Level file
            LoadLevel();
        }

        void LoadLevel()
        {
            //load the nbt file
            NbtFile levelDatNbtFile = new NbtFile();
            levelDatNbtFile.LoadFromFile(GetLevelDatPath());

            //load the data compound
            NbtCompound LevelDataCompound;

            //initialize a level class
            Level = new MLevel();

            if (levelDatNbtFile.RootTag != null)
            {
                //get the root tag
                LevelDataCompound = levelDatNbtFile.RootTag.Get<NbtCompound>("Data");

                //get level name
                Level.LevelName = LevelDataCompound.Get<NbtString>("LevelName")?.StringValue;
                //get level gamemode
                Level.LevelGameMode = (GameModes)LevelDataCompound.Get<NbtInt>("GameType")?.IntValue;
                //get level difficulty
                var difficulty = LevelDataCompound.Get<NbtByte>("Difficulty")?.ByteValue;
                if (difficulty.HasValue)
                {
                    Level.LevelDifficulty = (Difficulties)difficulty;
                }

                //get initialized
                Level.initialized = Convert.ToBoolean(LevelDataCompound.Get<NbtByte>("initialized")?.ByteValue);

                //get raining
                Level.IsRaining = Convert.ToBoolean(LevelDataCompound.Get<NbtByte>("raining")?.ByteValue);
                //get thundering
                Level.IsThundering = Convert.ToBoolean(LevelDataCompound.Get<NbtByte>("thundering")?.ByteValue);

                //get level version name
                Level.LevelVersion = new MinecraftNbtWorldViewer.Classes.MVersion();
                NbtCompound versioncompound = LevelDataCompound.Get<NbtCompound>("Version");
                if (versioncompound != null)
                {
                    foreach (NbtTag tag in versioncompound.Tags)
                    {
                        if (tag.TagType == NbtTagType.String && tag.Name == "Name")
                        {
                            Level.LevelVersion.name = tag.StringValue;
                        }
                        if (tag.TagType == NbtTagType.Byte && tag.Name == "id" && tag.HasValue)
                        {
                            Level.LevelVersion.id = tag.ByteValue;
                        }
                        if (tag.TagType == NbtTagType.Byte && tag.Name == "Snapshot" && tag.HasValue)
                        {
                            Level.LevelVersion.snapshot = tag.ByteValue;
                        }
                    }
                };

                //get allow commands from root
                Level.AllowCommands = Convert.ToBoolean(LevelDataCompound.Get<NbtByte>("allowCommands")?.ByteValue);
                //get locked difficulty from root
                Level.IsDifficultyLocked = Convert.ToBoolean(LevelDataCompound.Get<NbtByte>("DifficultyLocked")?.ByteValue);
                // get is hardcore from root
                Level.IsHardcore = Convert.ToBoolean(LevelDataCompound.Get<NbtByte>("hardcore")?.ByteValue);

                //get seed and map features
                NbtCompound WorldGenSettingsCompound = LevelDataCompound.Get<NbtCompound>("WorldGenSettings");
                if (WorldGenSettingsCompound != null)
                {
                    //world is 1.16+, get data from here
                    foreach (NbtTag tag in WorldGenSettingsCompound.Tags)
                    {
                        if (tag.HasValue && tag.TagType == NbtTagType.Long && tag.Name == "seed")
                        {
                            Level.Seed = tag.LongValue;
                        }

                        if (tag.HasValue && tag.TagType == NbtTagType.Byte && tag.Name == "generate_features")
                        {
                            Level.AreStructuresGenerated = Convert.ToBoolean(tag.ByteValue);
                        }

                        if (tag.HasValue && tag.TagType == NbtTagType.Byte && tag.Name == "bonus_chest")
                        {
                            Level.HasBonusChest = Convert.ToBoolean(tag.ByteValue);
                        }
                    }
                }
                else
                {
                    //world is 1.16-, get data directly from root
                    Level.AreStructuresGenerated = Convert.ToBoolean(LevelDataCompound.Get<NbtByte>("MapFeatures")?.ByteValue);

                    Level.Seed =LevelDataCompound.Get<NbtLong>("RandomSeed")?.LongValue;
                }

                Level.LastPlayed = TickToTimeConverter.GetTimeFromSecons(LevelDataCompound.Get<NbtLong>("LastPlayed")?.LongValue);

                Level.RemainingDayTimeSeconds = TickToTimeConverter.TicksToSeconds(LevelDataCompound.Get<NbtLong>("LastPlayed")?.LongValue);

                //get all gamerules
                Level.GameRulesList = new List<MGameRule>();
                NbtCompound gamerulesTag = LevelDataCompound.Get<NbtCompound>("GameRules");
                if (gamerulesTag != null)
                {
                    Level.GameRulesCount = gamerulesTag.Count;
                    foreach (NbtString tag in gamerulesTag.Tags)
                    {
                        MGameRule rule = new MGameRule();
                        if (tag.HasValue)
                        {
                            rule.HasValue = true;
                            rule.Value = tag.Value;
                        }
                        else
                        {
                            rule.HasValue = false;
                        }
                        rule.GameRule = tag.Name;

                        Level.GameRulesList.Add(rule);
                    }
                }

                Level.SpawnLocation = new MinecraftNbtWorldViewer.Classes.Positioning.MLocation();
                Level.SpawnLocation.X = LevelDataCompound.Get<NbtInt>("SpawnX")?.IntValue;
                Level.SpawnLocation.Y = LevelDataCompound.Get<NbtInt>("SpawnY")?.IntValue;
                Level.SpawnLocation.Z = LevelDataCompound.Get<NbtInt>("SpawnZ")?.IntValue;


                NbtCompound PlayerCompound = LevelDataCompound.Get<NbtCompound>("Player");
                //load player things
                Level.Player = new MinecraftNbtWorldViewer.Level.Player.MPlayer();

                //load abilites
                Level.Player.Abilities = new List<MAbility>();
                NbtCompound AbilitiesCompound = PlayerCompound.Get<NbtCompound>("abilities");
                foreach (NbtTag tag in AbilitiesCompound.Tags)
                {
                    MAbility ability = new MAbility();
                    if (tag.TagType == NbtTagType.Byte)
                    {
                        ability.ValueType = AbilityValueType.Boolean;
                        ability.BoolValue = Convert.ToBoolean(tag.ByteValue);
                    }
                    if (tag.TagType == NbtTagType.Float)
                    {
                        ability.ValueType = AbilityValueType.Float;
                        ability.FloatValue = tag.FloatValue;
                    }

                    ability.Name = tag.Name;

                    Level.Player.Abilities.Add(ability);
                }

                //load position
                Level.Player.Position = new MinecraftNbtWorldViewer.Classes.Positioning.MPosition();
                NbtList list = PlayerCompound.Get<NbtList>("Pos");

                double x = list[0].DoubleValue;
                double y = list[1].DoubleValue;
                double z = list[2].DoubleValue;

                Level.Player.Position.X = x;
                Level.Player.Position.Y = y;
                Level.Player.Position.Z = z;

                //load rotation
                Level.Player.Rotation = new MinecraftNbtWorldViewer.Classes.Positioning.MRotation();
                NbtList rot = PlayerCompound.Get<NbtList>("Rotation");

                float? yaw = rot[0].FloatValue;
                float? pitch = rot[1].FloatValue;

                Level.Player.Rotation.Yaw = yaw;
                Level.Player.Rotation.Pitch = pitch;

                //load motion
                Level.Player.Motion = new MinecraftNbtWorldViewer.Classes.Motion.MMotion();
                NbtList molist = PlayerCompound.Get<NbtList>("Pos");

                double mx = molist[0].DoubleValue;
                double my = molist[1].DoubleValue;
                double mz = molist[2].DoubleValue;

                Level.Player.Motion.X = mx;
                Level.Player.Motion.Y = my;
                Level.Player.Motion.Z = mz;

                //HERE: Implement other values (like gamemode, issleeping, xp, etc)





                //Inventory
                Level.Player.Inventory = new MinecraftNbtWorldViewer.Level.Player.Inventory.MInventory();
                Level.Player.Inventory.InventoryItems = new List<MInventoryItem>();
                NbtList InventoryCompound = PlayerCompound.Get<NbtList>("Inventory");
                Level.Player.Inventory.InventoryItemsCount = InventoryCompound.Count;
                foreach (NbtCompound ItemCompound in InventoryCompound)
                {
                    MInventoryItem inventoryItem = new MInventoryItem();

                    //get the count and slot (is the same on every version so far)
                    inventoryItem.Count = ItemCompound.Get<NbtByte>("Count").ByteValue;
                    inventoryItem.Slot = ItemCompound.Get<NbtByte>("Slot").ByteValue;

                    //get the id (string on 1.8+ (i think), else its a short)
                    NbtTag IDTag = ItemCompound.Get<NbtTag>("id");
                    if (IDTag.TagType == NbtTagType.Short)
                    {
                        inventoryItem.IDDataType = MInventoryItemIDDataType.Short;
                        inventoryItem.ShortID = IDTag.ShortValue;
                    }
                    else if (IDTag.TagType == NbtTagType.String)
                    {
                        inventoryItem.IDDataType = MInventoryItemIDDataType.String;
                        inventoryItem.StringID = IDTag.StringValue;
                    }



                    Level.Player.Inventory.InventoryItems.Add(inventoryItem);
                }
            }
        }


        public MLevel Level;
    }
}
