using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

public partial class EditorScene : Node2D
{

    private int BlockSize = 32;
    private int width = 10;
    private int height = 10;
    private int[,] grid;
    private Sprite2D cursor;
    //private Sprite2D block;
    //запись в память
    //private List<ABlock> blocks = new List<ABlock>();
   
    public override void _Ready()
    {
        grid = new int[width, height];

        cursor = GetNode<Sprite2D>("cursor");
        if(cursor == null)
        {
            GD.Print("error, line 10");
        }

        cursor.Texture = GD.Load<Texture2D>("res://blocks/a_block/a_block.png");

        //строительство сетки
        for(int i = 0; i <= 10; i++)
        {
            for(int j = 0; j <= 10; j++)
            {
                
            }
        }

        //block = GetNode<Sprite2D>("");
    }

    public override void _Process(double delta)
    {
        var mousePos = GetViewport().GetMousePosition();
        Vector2 grid = mousePos.Snapped(new Vector2(32,32));
        cursor.Position = grid;
        if(Input.IsActionJustPressed("place"))
        {
            PlaceBlock(grid);
        }
        if(Input.IsActionJustPressed("chek"))
        {
            ShowBlockList();
        }
    }

    public void PlaceBlock(Vector2 grid)
    {
        //GD.Print(grid.X);
        //block.Position = new Vector2(grid.X, grid.Y);
        Sprite2D obj = new Sprite2D();
        obj.Texture = GD.Load<Texture2D>("res://blocks/a_block/a_block.png");
        obj.Position = grid;
        GetTree().CurrentScene.AddChild(obj);
        //blocks.Add(new ABlock("Basic", grid));
    }

    private void ShowBlockList()
    {
        GD.Print("===Block-List===");
        //foreach(var b in blocks)
        { 
           //GD.Print(b.Type, " @ ", b.Pos); 
        }
        GD.Print("==============="); 
        
    }



}
