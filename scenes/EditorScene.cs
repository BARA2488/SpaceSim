using Godot;
using GodotPlugins.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

public partial class EditorScene : Node2D
{

    private int BlockSize = 32;
    private int width = 40;
    private int height = 40;
    
    private Sprite2D cursor;
    //private Sprite2D block;
    //запись в память
    //private List<ABlock> blocks = new List<ABlock>();

    private AudioStreamPlayer mouse_entered;
    private AudioStreamPlayer mouse_pressed;

    //сборка
    private string current_part;

    public List<Part> ShipParts = new();
    public Part[,] Grid = new Part[40, 40];
    private Vector2 placePosition;

    public override void _Ready()
    {

        mouse_entered = GetNode<AudioStreamPlayer>("mouse_entered");
        mouse_pressed = GetNode<AudioStreamPlayer>("button_pressed");

        cursor = GetNode<Sprite2D>("cursor");
        if(cursor == null)
        {
            GD.Print("error, line 10");
        }

        //cursor.Texture = GD.Load<Texture2D>("res://blocks/a_block/a_block.png");
        //block = GetNode<Sprite2D>("");

    }

    public override void _Process(double delta)
    {
        var mousePos = GetViewport().GetMousePosition();
        Vector2 grid = mousePos.Snapped(new Vector2(32,32));
        Vector2 cell = (grid / 32).Floor();
        cursor.Position = grid;
        placePosition = new Vector2(cell.X, cell.Y);

        if(Input.IsActionJustPressed("place"))
        {
            if(current_part != null)
            {
                AddPart(current_part, (int)placePosition.X, (int)placePosition.Y);
                Print($"{(int)placePosition.X}, {(int)placePosition.Y}");
            }
        }
    }

    //установка детали
    private void AddPart(string type, int x, int y)
    {
        //проверка занятости клетки
        if(Grid[x, y] != null){Print($"Error, the {type} cannot be added, because the cell {x} {y} is busy "); return;}

        //создание детали
        var part = new Part(type);
        var data = PART_DB.Data[part.Type];
        var tex = GD.Load<Texture2D>(data.TexturePath);

        //позиция
        part.GridPos = new Vector2I(x, y);

        ShipParts.Add(part);
        Grid[x, y] = part;

        //размещение текстуры для наглядности
        Sprite2D sprite = new Sprite2D();
        sprite.Texture = tex;
        sprite.Position = new Vector2I(x * 32, y * 32);
        AddChild(sprite);

        Print($"Part added: {part.Type}");
        Print($"Placed at:  + {x}, {y}");
    }

    public PackedScene BuildShipScene()
    {
        var shipRoot = new Rocket();
        shipRoot.Name = "Ship";

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                var part = Grid[x, y];
                if(part == null)
                    //GD.Print("Place part error");
                    continue;
                
                var data = PART_DB.Data[part.Type];


                var sprite = new Sprite2D();
                var tex = GD.Load<Texture2D>(data.TexturePath);
                sprite.Texture = tex;
                Print($"Texture = {tex}");
                sprite.Position = new Vector2(x * 32, y * 32);
                shipRoot.AddChild(sprite);

                var col = new CollisionShape2D();
                col.Shape = new RectangleShape2D() {Size = new Vector2(32,32)};
                col.Position = sprite.Position;
                shipRoot.AddChild(col);
                //GD.Print("Place part error");
            }
        }

        var result = new PackedScene();
        result.Pack(shipRoot);
        Print("Rocket Created");
        Print($"{shipRoot.GetChildCount()}");

        return result;
    }


    //звуки кнопок
    private void _on_fueltank_mouse_entered()
    {
        mouse_entered.Play();
    }
    
    private void _on_cockpit_mouse_entered()
    {
        mouse_entered.Play();
    }

    private void _on_engine_mouse_entered()
    {
        mouse_entered.Play();
    }
    //нажатия кнопок
    private void _on_cockpit_pressed()
    {
        mouse_pressed.Play();
        cursor.Texture = GD.Load<Texture2D>("res://PartsTextures/Cockpit.png");
        current_part = "cockpit";
    }
    private void _on_fueltank_pressed()
    {
        mouse_pressed.Play();
        cursor.Texture = GD.Load<Texture2D>("res://PartsTextures/fuel_tank.png");
        current_part = "fuel_tank";
    }
    private void _on_engine_pressed()
    {
        mouse_pressed.Play();
        cursor.Texture = GD.Load<Texture2D>("res://PartsTextures/engine.png");
        current_part = "engine";
    }

    private async void _on_create_pressed()
    {
        var shipScene = BuildShipScene();
        GameManager.Instance.StartGame(shipScene);
        GD.Print($"Editor" + shipScene.Instantiate().GetChildCount());
    }
    public static String Print(string word)
    {
        GD.Print(word);
        return word;
    }
}
