using MinecraftNbtWorld.Enums;
using System;
using System.Collections.Generic;
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
        public string? LevelVersion;

        public bool AllowCommands;
        public bool IsDifficultyLocked;
        public bool IsHardcore;
        public bool AreStructuresGenerated;

        public long? Seed;

        public DateTime? CreatedAt;
        public DateTime? LastPlayed;

        public MGameRules? GameRules;
    }
}
