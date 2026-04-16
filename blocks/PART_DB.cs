using Godot;
using System;
using System.Collections.Generic;

public partial class PART_DB
{
    public float Mass;
    public float FuelCapacity;
    public float Thrust;
    public string TexturePath;
    //public float FuelAmount;

    public static Dictionary<string, PART_DB> Data = new()
    {
        {
            "fuel_tank", new PART_DB
            {
                Mass = 1.0f,
                FuelCapacity = 50f,
                Thrust = 0f,
                TexturePath = "res://PartsTextures/fuel_tank.png"
            }
        },
        {
            "engine", new PART_DB
            {
                Mass = 1.0f,
                FuelCapacity = 50f,
                Thrust = 0f,
                TexturePath = "res://PartsTextures/engine.png"
            }
        },
        {
            "cockpit", new PART_DB
            {
                Mass = 1.0f,
                FuelCapacity = 0f,
                Thrust = 0f,
                TexturePath = "res://PartsTextures/Cockpit.png"
            }
        }
    };
}
