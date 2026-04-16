using Godot;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

public partial class PartTester : Node
{
    public List<Part> ShipParts = new();
    public Part[,] Grid = new Part[50, 50];
    public override void _Ready()
    {

        AddPart("engine", 0, 0);
        AddPart("fuel_tank", 0, 0);
        AddPart("fuel_tank", 0, 1);
        AddPart("fuel_tank", 0, 2);
        AddPart("fuel_tank", 0, 3);
        AddPart("fuel_tank", 0, 4);

        PartsList();
        
    }
    private void AddPart(string type, int x, int y)
    {   /*
        //проверка занятости клетки
        if(Grid[x, y] != null){Print($"Error, the {type} cannot be added, because the cell {x} {y} is busy "); return;}

        //создание детали
        var p = new Part();
        p.Type = type;

        //считывание данных из базы
        var data = PART_DB.Data[p.Type];
        p.Mass = data["mass"];
        p.FuelCapacity = data["fuel_capacity"];
        p.FuelAmount = p.FuelCapacity;
        p.Thrust = data["thrust"];

        //позиция
        p.GridPos = new Vector2I(x, y);

        ShipParts.Add(p);
        Grid[x, y] = p;

        Print($"Part added: {p.Type}");
        */
    }

    private void PartsList()
    {
        //Вывод массива
        Print("\n==ВЫВОД-МАССИВА==");
        foreach(var part in ShipParts)
        {
            Print($"\n-PART-INFO-\nType: {part.Type}\nMass: {part.Mass}");
            if(part.Type == "fuel_tank"){Print("Вместимость топлива: " + part.FuelCapacity);Print("Количество топлива: " + part.FuelAmount);}else{Print("Тяга:" + part.Thrust);}
            Print($"Position: {part.GridPos}");
        }
        
        /*
        foreach(var part in Grid)
        {
            if(part != null){Print(Grid);}
        }
        */
    }

    public static String Print(string word)
    {
        GD.Print(word);
        return word;
    }
}
