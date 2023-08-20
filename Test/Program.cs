using CmlLib.Core;
using MinecraftNbtWorld;

//MWorld world = new MWorld(MinecraftPath.GetOSDefaultPath() + "\\saves\\" + "\\1_2_5 Test");
//MWorld world = new MWorld(MinecraftPath.GetOSDefaultPath() + "\\saves\\" + "\\Survival 1_9_4");
MWorld world = new MWorld(MinecraftPath.GetOSDefaultPath() + "\\saves\\" + "\\Minecraft Survival 1_16_5");
//MWorld world = new MWorld(MinecraftPath.GetOSDefaultPath() + "\\saves\\" + "\\1_17_1 amplified");

Console.WriteLine("Level name: " + world.Level.LevelName);
Console.WriteLine("Level GameMode: " + world.Level.LevelGameMode.ToString());
Console.WriteLine("Level Difficulty: " + world.Level.LevelDifficulty.ToString());
Console.WriteLine("Level Version: " + world.Level.LevelVersion.name);

Console.WriteLine();

Console.WriteLine("Are commands allowed: "+world.Level.AllowCommands.ToString());
Console.WriteLine("Is difficulty locked: "+world.Level.IsDifficultyLocked.ToString());
Console.WriteLine("Is Hardcore: "+world.Level.IsHardcore.ToString());
Console.WriteLine("Are structures generated: "+world.Level.AreStructuresGenerated.ToString());
Console.WriteLine("Has generated bonus chest: "+world.Level.HasBonusChest.ToString());
Console.WriteLine("Level Initialized: "+world.Level.initialized.ToString());

Console.WriteLine();
Console.WriteLine("Is Thundering: " + world.Level.IsThundering.ToString());
Console.WriteLine("Is Raining: " + world.Level.IsRaining.ToString());
Console.WriteLine();

Console.WriteLine("Seed: "+world.Level.Seed.ToString());

Console.WriteLine();

Console.WriteLine("Last played at: " + world.Level.LastPlayed.ToString());
Console.WriteLine("Remaining day time: " + world.Level.RemainingDayTimeSeconds.ToString());

Console.WriteLine();

Console.WriteLine("All GameRules: ");
foreach (var rule in world.Level.GameRulesList)
{
    Console.WriteLine(rule.GameRule + ", " + rule.Value);
}

Console.WriteLine();
Console.WriteLine("World Spawn Location: ");
Console.WriteLine("X: " + world.Level.SpawnLocation.X);
Console.WriteLine("Y: " + world.Level.SpawnLocation.Y);
Console.WriteLine("Z: " + world.Level.SpawnLocation.Z);