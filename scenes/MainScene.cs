using Godot;
using System;

public partial class MainScene : Node2D
{

    EditorScene editorScene;

    public void SpawnShip(PackedScene shipScene)
    {
        var ship = shipScene.Instantiate<Node2D>();
        //правильный спавн корабля - его нижняя деталь должна появляться на координатах (0, 0)
        AddChild(ship);
        //ship.Position = new Vector2(0, -editorScene.minPartPos * 32);
        GD.Print(ship.Name);
        GD.Print($"Колво деталей в мейне: {ship.GetChildCount()}");
    }
    public override void _PhysicsProcess(double delta)
    {
        //GD.Print(GetChildCount());
    }

}
