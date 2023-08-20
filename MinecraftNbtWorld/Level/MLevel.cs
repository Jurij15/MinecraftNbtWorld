using CmlLib.Core.Version;
using MinecraftNbtWorld.Enums;
using MinecraftNbtWorldViewer.Level.GameRule;
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
        public MinecraftNbtWorldViewer.Level.Version.MVersion LevelVersion;

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

        public List<MGameRule> GameRulesList;
    }
}
