using CmlLib.Core.Version;
using MinecraftNbtWorld.Enums;
using MinecraftNbtWorldViewer.Classes;
using MinecraftNbtWorldViewer.Classes.Positioning;
using MinecraftNbtWorldViewer.Level.Player;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftNbtWorld.Level
{
    public class MLevel
    {
        public string? LevelName;
        public GameModes? LevelGameMode;
        public Difficulties? LevelDifficulty;
        public MinecraftNbtWorldViewer.Classes.MVersion? LevelVersion;

        public bool AllowCommands;
        public bool IsDifficultyLocked;
        public bool IsHardcore;
        public bool AreStructuresGenerated;
        public bool HasBonusChest;

        public bool initialized;
        public bool IsModded;

        public bool IsRaining;
        public bool IsThundering;

        public long? Seed;

        public DateTime? LastPlayed;

        public double RemainingDayTimeSeconds;

        public int GameRulesCount;
        public List<MGameRule> GameRulesList;

        public MLocation? SpawnLocation;

        //player
        public MPlayer Player;
    }
}
