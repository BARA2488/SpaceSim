using Godot;
using System;

public partial class Rocket : RigidBody2D
{
    public override void _Ready()
    {
        GD.Print("Hello from rocket");
    }

}
