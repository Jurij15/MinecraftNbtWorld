using CmlLib.Core;
using MinecraftNbtWorld;

MWorld world = new MWorld(MinecraftPath.GetOSDefaultPath() + "\\saves\\" + "\\1_17_1 amplified");

Console.WriteLine("Level name: " + world.Level.LevelName);
Console.WriteLine("Level GameMode: " + world.Level.LevelGameMode.ToString());
Console.WriteLine("Level Difficulty: " + world.Level.LevelDifficulty.ToString());
Console.WriteLine("Level Version: " + world.Level.LevelVersion);

Console.WriteLine();

Console.WriteLine("Are commands allowed: "+world.Level.AllowCommands.ToString());
Console.WriteLine("Is difficulty locked: "+world.Level.IsDifficultyLocked.ToString());
Console.WriteLine("Is Hardcore: "+world.Level.IsHardcore.ToString());
Console.WriteLine("Are structures generated: "+world.Level.AreStructuresGenerated.ToString());

Console.WriteLine();

Console.WriteLine("Seed: "+world.Level.Seed.ToString());