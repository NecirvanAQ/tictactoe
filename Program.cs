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
        if (places.Contains(0) && places.Contains(1) && places.Contains(2))
        {
            return true;
        }

        if (places.Contains(10) && places.Contains(11) && places.Contains(12))
        {
            return true;
        }

        if (places.Contains(20) && places.Contains(21) && places.Contains(22))
        {
            return true;
        }

        if (places.Contains(0) && places.Contains(11) && places.Contains(22))
        {
            return true;
        }

        if (places.Contains(2) && places.Contains(11) && places.Contains(20))
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

        while (true)
        {
            DrawGrid(player1, player2);
            Player.Play(player1.places);

            Check(player1);

            DrawGrid(player1, player2);
            Player.Play(player2.places);

            Check(player2);

        }
        
    }
    static void Check(Player player)
    {
        if (Player.Won(player.places) == true)
        {
            Console.Clear();
            Console.WriteLine($"{player} wins!");
            Console.ReadKey();
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
