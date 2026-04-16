using Godot;
using System;

public partial class MainScene : Node2D
{
    public void SpawnShip(PackedScene shipScene)
    {
        var ship = shipScene.Instantiate<Node2D>();
        ship.Position = Vector2.Zero;
        AddChild(ship);
        GD.Print(ship.Name);
        GD.Print(ship.GetChildCount());
    }
    public override void _PhysicsProcess(double delta)
    {
        //GD.Print(GetChildCount());
    }

}
