using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


class Player
{
    int score = 0;
    public List<int> places = new List<int>();

    public static void Play(List<int> places)
    {
        Console.WriteLine("Your move: ");
        int place = Convert.ToInt32(Console.ReadLine());
        places.Add(place);
    }

    public static bool Won(List<int> places)
    {
        if (places.Contains(00) && places.Contains(01) && places.Contains(02))
        {
            return true;
        }

        return false;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Player player1 = new Player();
        Player player2 = new Player();
        

        while (Player.Won(player1.places) == false || Player.Won(player2.places) == false)
        {
            DrawGrid(player1, player2);
            Player.Play(player1.places);
            DrawGrid(player1, player2);
            Player.Play(player2.places);
        }
        
    }
    static void DrawGrid(Player player1, Player player2)
    {
        Console.Clear();
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        List<List<string>> grid = new List<List<string>>();
        grid.Add(new List<string> { "", "", "" });
        grid.Add(new List<string> { "", "", "" });
        grid.Add(new List<string> { "", "", "" });

        foreach (int place in player1.places)
        {
            grid[(place / 10) % 10][place % 10] = "O";
        }

        foreach (int place in player2.places)
        {
            grid[(place / 10) % 10][place % 10] = "X";
        }

        foreach (var list in grid)
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
