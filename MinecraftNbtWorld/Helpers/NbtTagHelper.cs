using fNbt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftNbtWorld.Helpers
{
    public class NbtTagHelper
    {
        public static bool IsTagNull(NbtTag Tag)
        {
            if (Tag == null) return true;
            else
            {
                return false;
            }
        }
    }
}
