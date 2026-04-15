using Godot;
using System;
using System.Collections.Generic;

public partial class PART_DB
{
    public static Dictionary<string, Dictionary<string, float>> Data =
    new()
    {
        {
            "fuel_tank", new  Dictionary<string, float>
            {
                { "mass", 1.0f },
                { "fuel_capacity", 50f },
                { "thrust", 0f}
            }
        },
        {
            "engine", new Dictionary<string, float>
            {
                { "mass", 0.5f },
                { "fuel_capacity", 0f },
                { "thrust", 20f}
            }
        }
    };
}
