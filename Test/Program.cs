using CmlLib.Core;
using MinecraftNbtWorld;
using MinecraftNbtWorldViewer.Classes;
using MinecraftNbtWorldViewer.Classes.Enchantments;
using MinecraftNbtWorldViewer.Classes.Inventory;

//MWorld world = new MWorld(MinecraftPath.GetOSDefaultPath() + "\\saves\\" + "\\1_2_5 Test");
//MWorld world = new MWorld(MinecraftPath.GetOSDefaultPath() + "\\saves\\" + "\\Survival 1_9_4");
//MWorld world = new MWorld(MinecraftPath.GetOSDefaultPath() + "\\saves\\" + "\\Minecraft Survival 1_16_5");
foreach (var item in Directory.GetDirectories(MinecraftPath.GetOSDefaultPath()+"\\saves"))
{
    //Console.WriteLine(item);
    if (File.Exists(item+"\\level.dat"))
    {
        //MWorld mworld = new MWorld(item);
    }
}
MWorld world = new MWorld(MinecraftPath.GetOSDefaultPath() + "\\saves\\" + "\\1_17_1 amplified");

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

Console.WriteLine("All GameRules with values: ");
foreach (var rule in world.Level.GameRulesList)
{
    Console.WriteLine(rule.GameRule + ", " + rule.Value);
}

Console.WriteLine();
Console.WriteLine("World Spawn Location: ");
Console.WriteLine("X: " + world.Level.SpawnLocation.X);
Console.WriteLine("Y: " + world.Level.SpawnLocation.Y);
Console.WriteLine("Z: " + world.Level.SpawnLocation.Z);

Console.WriteLine();
Console.WriteLine("------Player Details------");
Console.WriteLine();

Console.WriteLine("Player Abilities: ");
foreach (MAbility ability in world.Level.Player.Abilities)
{
    string message;
    message = ability.Name;
    if (ability.ValueType == AbilityValueType.Boolean)
    {
        message = message + ", " + ability.BoolValue;
    }
    else if (ability.ValueType == AbilityValueType.Float)
    {
        message = message + ", " + ability.FloatValue;
    }
    Console.WriteLine(message);
}

Console.WriteLine();

Console.WriteLine("Player Position: ");
Console.WriteLine("X: " + world.Level.Player.Position.X);
Console.WriteLine("Y: " + world.Level.Player.Position.Y);
Console.WriteLine("Z: " + world.Level.Player.Position.Z);

Console.WriteLine();

Console.WriteLine("Player Motion: ");
Console.WriteLine("X: " + world.Level.Player.Motion.X);
Console.WriteLine("Y: " + world.Level.Player.Motion.Y);
Console.WriteLine("Z: " + world.Level.Player.Motion.Z);

Console.WriteLine();

Console.WriteLine("Player Rotation: ");
Console.WriteLine("Yaw: " + world.Level.Player.Rotation.Yaw);
Console.WriteLine("Pitch: " + world.Level.Player.Rotation.Pitch);

Console.WriteLine();

Console.WriteLine($"Player Inventory (Total Items {world.Level.Player.Inventory.InventoryItemsCount.ToString()}): ");
foreach (MInventoryItem item in world.Level.Player.Inventory.InventoryItems)
{
    Console.WriteLine("-*-*Inventory item*-*-");
    Console.WriteLine("Count: "+item.Count.ToString());
    Console.WriteLine("Slot: " + item.Slot.ToString());
    if (item.IDDataType == MInventoryItemIDDataType.Short)
    {
        Console.WriteLine("ID: "+item.ShortID.ToString());
    }
    if (item.IDDataType == MInventoryItemIDDataType.String)
    {
        Console.WriteLine("ID: " + item.StringID.ToString());
    }
    Console.WriteLine("Repair Cost: " + item.RepairCost.ToString());
    if (item.DamageDataType == MInventoryItemDamageDataType.Short)
    {
        Console.WriteLine("Damage: " + item.ShortDamage.ToString());
    }
    if (item.DamageDataType == MInventoryItemDamageDataType.Integer)
    {
        Console.WriteLine("Damage: " + item.IntegerDamage.ToString());
    }
    Console.WriteLine($"Enchantments (id,level), count: {item.Enchantments.Count}:");
    foreach (MEnchantment enchantment in item.Enchantments)
    {
        string message = "";
        if (enchantment.IDDataType == MEnchantmentIDDataType.Short)
        {
            message = message + enchantment.ShortID;
        }
        else if (enchantment.IDDataType == MEnchantmentIDDataType.String)
        {
            message = message + enchantment.StringID;
        }

        message = message + ", " + enchantment.Level;

        Console.WriteLine(message);
    }
}