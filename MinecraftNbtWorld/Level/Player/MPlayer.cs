using MinecraftNbtWorld.Enums;
using MinecraftNbtWorldViewer.Classes;
using MinecraftNbtWorldViewer.Classes.Inventory;
using MinecraftNbtWorldViewer.Classes.Motion;
using MinecraftNbtWorldViewer.Classes.Positioning;
using MinecraftNbtWorldViewer.Level.Player.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftNbtWorldViewer.Level.Player
{
    public class MPlayer
    {
        public MPosition? Position;
        public MRotation? Rotation;
        public MMotion? Motion;

        public List<MAbility>? Abilities;

        public MInventory? Inventory;

        public int? Dimension;

        public float? FoodExhaustionLevel;
        public int? FoodLevel;
        public float? FoodSaturationLevel;
        public int? FoodTickTimer;

        public short? Health;

        public bool? OnGround;

        public int? PlayerGameType;
        public GameModes? PlayerGameMode; //easier to use

        public bool? Sleeping;

        public int? XpLevel;
        public float? XpP;
        public int? XpTotal;
    }
}
