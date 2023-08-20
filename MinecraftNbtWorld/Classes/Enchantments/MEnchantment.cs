using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftNbtWorldViewer.Classes.Enchantments
{
    public enum MEnchantmentIDDataType
    {
        Short,
        String
    }
    public class MEnchantment
    {
        public MEnchantmentIDDataType IDDataType;

        public short? Level;

        public short? ShortID;
        public string? StringID;
    }
}
