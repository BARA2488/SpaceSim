using Godot;
using System;

public partial class Part : Resource
{
    public string Type { get; set; }
    public Vector2I GridPos { get; set; }

    public float Mass { get; set; }
    public float FuelCapacity { get; set; }
    public float FuelAmount { get; set; }
    public float Thrust { get; set; }
    public string TexturePath { get; set; }

    public Part(string type)
    {
        Type = type;

        var data = PART_DB.Data[type];
        Mass = data.Mass;
        FuelCapacity = data.FuelCapacity;
        Thrust = data.Thrust;
        FuelAmount = data.FuelCapacity;
        TexturePath = data.TexturePath;
    }
}
