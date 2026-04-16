using Godot;
using GodotPlugins.Game;
using System;

public partial class GameManager : Node
{
    public static GameManager Instance { get; private set; }
    public PackedScene ShipToSpawn;

    public override void _Ready()
    {
        Instance = this;
    }


    public async void StartGame(PackedScene ship)
    {
        ShipToSpawn = ship;

        GetTree().ChangeSceneToFile("res://scenes/main_scene.tscn");
        await ToSignal(GetTree(), "tree_changed");

        var main = GetTree().CurrentScene as MainScene;
        main.SpawnShip(ShipToSpawn);
    }
}
