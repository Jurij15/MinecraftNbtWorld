using fNbt;
using MinecraftNbtWorld.Enums;
using MinecraftNbtWorld.Level;
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
            //Load the NbtFile and DataCompound



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
                LevelDataCompound = levelDatNbtFile.RootTag.Get<NbtCompound>("Data");

                Level.LevelName = LevelDataCompound.Get<NbtString>("LevelName")?.StringValue;
                Level.LevelGameMode = (GameModes)LevelDataCompound.Get<NbtInt>("GameType")?.IntValue;
                Level.LevelDifficulty = (Difficulties)LevelDataCompound.Get<NbtByte>("Difficulty")?.ByteValue;

                NbtCompound versioncompound = LevelDataCompound.Get<NbtCompound>("Version");
                if (versioncompound != null)
                {
                    foreach (NbtTag tag in versioncompound.Tags)
                    {
                        if (tag.TagType == NbtTagType.String && tag.Name == "Name")
                        {
                            Level.LevelVersion = tag.StringValue; break;
                        }
                    }
                };

                Level.AllowCommands = Convert.ToBoolean(LevelDataCompound.Get<NbtByte>("allowCommands")?.ByteValue);
                Level.IsDifficultyLocked = Convert.ToBoolean(LevelDataCompound.Get<NbtByte>("DifficultyLocked")?.ByteValue);
                Level.IsHardcore = Convert.ToBoolean(LevelDataCompound.Get<NbtByte>("hardcore")?.ByteValue);

                //in this case, we have a pre 1.16 world, and this is saved directly in data
                byte? oldMapFeatures = LevelDataCompound.Get<NbtByte>("MapFeatures")?.ByteValue;
                if (oldMapFeatures.HasValue)
                {
                    Level.AreStructuresGenerated = Convert.ToBoolean(oldMapFeatures);
                }

                long? oldSeed = LevelDataCompound.Get<NbtLong>("RandomSeed")?.LongValue;
                if (oldSeed.HasValue)
                {
                    //this is probably a pre 1.16 world
                    Level.Seed = oldSeed.Value;
                }
                else
                {
                    //this world is 1.16 or newer, we need to go to WorldGenSettings Compound and find seed there
                    NbtCompound WorldGenSettingsCompound = LevelDataCompound.Get<NbtCompound>("WorldGenSettings");
                    if (WorldGenSettingsCompound != null)
                    {
                        foreach (NbtTag tag in WorldGenSettingsCompound.Tags)
                        {
                            if (tag.HasValue && tag.TagType == NbtTagType.Long && tag.Name == "seed")
                            {
                                Level.Seed = tag.LongValue;
                            }

                            //we can also look for generate featues here
                            if (tag.HasValue && tag.TagType == NbtTagType.Byte && tag.Name == "generate_features")
                            {
                                Level.AreStructuresGenerated = Convert.ToBoolean(tag.ByteValue);
                            }
                        }
                    }
                }
            }
        }


        public MLevel Level;
    }
}
