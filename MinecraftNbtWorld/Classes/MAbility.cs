using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftNbtWorldViewer.Classes
{
    public enum AbilityValueType
    {
        Boolean,
        Float
    }
    public class MAbility
    {
        public AbilityValueType? ValueType;

        public string? Name;

        public bool? BoolValue;
        public float? FloatValue;
    }
}
