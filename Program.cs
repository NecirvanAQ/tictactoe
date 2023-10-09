using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Player
{
    int score = 0;
    public List<int> places = new List<int>();

    public static void Play(List<int> places)
    {
        Console.WriteLine("Player 1: ");
        int place = Convert.ToInt32(Console.ReadLine());
        places.Add(place);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Player player1 = new Player();

        while (true)
        {
            DrawGrid(player1);
            Player.Play(player1.places);
        }
        
    }
    static void DrawGrid(Player player1)
    {
        Console.Clear();
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        List<List<string>> grid = new List<List<string>>();
        grid.Add(new List<string> { "", "", "" });
        grid.Add(new List<string> { "", "", "" });
        grid.Add(new List<string> { "", "", "" });

        foreach(int place in player1.places)
        {
            grid[(place / 10) % 10][place % 10] = "X";
        }

        foreach(var list in grid)
        {
            Console.WriteLine("__________");

            foreach(var item in list)
            {
                Console.Write($"| {item} ");
            }
            Console.WriteLine("|");
            Console.WriteLine("‾‾‾‾‾‾‾‾‾‾");
        }
    }
}
