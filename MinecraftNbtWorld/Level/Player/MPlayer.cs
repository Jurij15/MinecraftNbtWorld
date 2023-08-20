using MinecraftNbtWorldViewer.Classes;
using MinecraftNbtWorldViewer.Classes.Motion;
using MinecraftNbtWorldViewer.Classes.Positioning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftNbtWorldViewer.Level.Player
{
    public class MPlayer
    {
        //THESE PROPERTIES WERE IN 1.2.5
        public MPosition? Position;
        public MRotation? Rotation;
        public MMotion? Motion;

        public List<MAbility> Abilities;

        //INVENTORY
        //Inventory is weird, newer versions have different data types and properties
        //They changed it on 1.8 I believe

        //idk if any of these are usefull, but here are all of them
        public short? Air;
        public short? AttackTime;
        public short? DeathTime;
        public int? Dimension;
        public float? FallDistance;
        public short? Fire;

        public float? FoodExhaustionLevel;
        public int? FoodLevel;
        public float? FoodSaturationLevel;
        public int? FoodTickTimer;

        public short? Health;
        public short? HurtTime;

        public byte? OnGround;

        public int? PlayerGameType;

        public byte? Sleeping;
        public short? SleepTimer;

        public int? XpLevel;
        public float? XpP;
        public int? XpTotal;

        //THESE PROPERTIES WERE IN MY 1.17.1 WORLD
        //i will add ones that are missing
    }
}
