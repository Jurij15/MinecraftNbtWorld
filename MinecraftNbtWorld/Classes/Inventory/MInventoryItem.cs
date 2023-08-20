using MinecraftNbtWorldViewer.Classes.Enchantments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftNbtWorldViewer.Classes.Inventory
{
    public enum MInventoryItemIDDataType
    {
        Short,
        String
    }
    public enum MInventoryItemDamageDataType
    {
        Short,
        Integer
    }
    public class MInventoryItem
    {
        public MInventoryItemIDDataType IDDataType;
        public MInventoryItemDamageDataType DamageDataType;

        public byte? Count;
        public byte? Slot;

        public short? ShortID;
        public string? StringID;

        public short? ShortDamage;
        public int? IntegerDamage;

        public int? RepairCost;


        public List<MEnchantment> Enchantments;
    }
}
