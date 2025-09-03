using System;
public class Game
{
    //Global Varibles
    public static string emty = "e";
    public static string pl1 = "";
    public static string pl2 = "";
    public static int turn = 0;
    public static bool gameover = false;
    public static string[] game_board = new string[9];
    public static string[] players = new string[2];
    public static string currentplayer = "";
    


    public static void Main()
    {
        Game.turn = 0;
        Game.gameover = false;
        for (int i = 0; i < Game.game_board.Length; i++)
        {
            Game.game_board[i] = emty;
        }
        Console.WriteLine("Player One: Please input your letter or number you want to use: ");
        Game.pl1 = Console.ReadLine();
        Game.players[0] = pl1;
        Console.WriteLine("Player Two: Please input your letter or number you want to use: ");
        Game.pl2 = Console.ReadLine();
        Game.players[1] = pl2;



        Game_Loop();
    }

    public static void Draw_Game() 
    {
        Console.WriteLine("\n");
        Console.WriteLine(game_board[0] + " | " + game_board[1] + " | " + game_board[2] + "     1 | 2 | 3");
        Console.WriteLine("---------");
        Console.WriteLine(game_board[3] + " | " + game_board[4] + " | " + game_board[5] + "     4 | 5 | 6");
        Console.WriteLine("---------");
        Console.WriteLine(game_board[6] + " | " + game_board[7] + " | " + game_board[8] + "     7 | 8 | 9");
        Console.WriteLine("\n");

    }

    public static void Check_Rows()
    {

        if ((game_board[0] == currentplayer) && (game_board[1] == currentplayer) && (game_board[2] == currentplayer) || 
            (game_board[3] == currentplayer) && (game_board[4] == currentplayer) && (game_board[5] == currentplayer) ||
            (game_board[6] == currentplayer) && (game_board[7] == currentplayer) && (game_board[8] == currentplayer))
            {
            Game.gameover = true;
            Win_Check();
        }
    }

    public static void Check_Collums()
    {
        bool collum_1 = ((game_board[0] = game_board[1] = game_board[2]) != emty) && (game_board[0] = game_board[1] = game_board[2] = pl1 || pl2);
        bool collum_2 = ((game_board[0] = game_board[1] = game_board[2]) != emty) && (game_board[0] = game_board[1] = game_board[2] = pl1 || pl2);
        bool collum_3 = ((game_board[0] = game_board[1] = game_board[2]) != emty) && (game_board[0] = game_board[1] = game_board[2] = pl1 || pl2);

        if (collum_1 || collum_2 || collum_3) {
            Game.gameover = true;
            Win_Check();
        }
    }

    public static void Check_Diags()
    {
        bool diag_1 = ((game_board[0] = game_board[1] = game_board[2]) != emty) && (game_board[0] = game_board[1] = game_board[2] = pl1 || pl2);
        bool diag_2 = ((game_board[0] = game_board[1] = game_board[2]) != emty) && (game_board[0] = game_board[1] = game_board[2] = pl1 || pl2);

        if (diag_1 || diag_2) {
            Game.gameover = true;
            Win_Check();
        }
    }

    public static void Check_Tie()
    {
       if (Array.Exists(game_board, element => element = emty) = false)
       {
        turn = 3;
        gameover = true;
        Win_Check();
       }
    }

    public static void Game_Over()
    {
        if (Game.turn = 1)
        {
            Draw_Game();
            Console.WriteLine("Player One Wins!");
            Console.WriteLine("Game Over!");
            Play_Again();
        }
        else if (Game.turn = 2)
        {
            Draw_Game();
            Console.WriteLine("Player Two Wins!");
            Console.WriteLine("Game Over!");
            Play_Again();
        }
        else if (Game.turn = 3)
        {
            Draw_Game();
            Console.WriteLine("Tie!");
            Console.WriteLine("Game Over!");
            Play_Again();
        }
    }

    public static void Win_Check() 
    {
        if (Game.gameover = true)
        {
            Game_Over();
        }
        else 
        {
            return;
        }
    }

    public static void Checks()
    {
        Check_Rows();
        Check_Collums();
        Check_Diags();
        Check_Tie();
    }

    public static void Game_Loop() 
    {
        Draw_Game();
        Player_One();

        Checks();

        Draw_Game();
        Player_Two();

        Checks();

        Game_Loop();
    }

    public static void Play_Again()
    {
        Main();
    }

    public static void Player_One()
    {
        Game.currentplayer = pl1;
        Console.WriteLine("Player One: Please select a number 1 to 9: ");
        int userturn = Convert.ToInt32(Console.ReadLine());
        userturn = userturn - 1;
        Game.turn = 1;

        if (userturn > 8 | userturn < 0)
        {
            Console.WriteLine("Selection is not 1-9");
            Player_One();
        }
        else 
        {
            if (game_board[userturn] = emty)
            {
                game_board[userturn] = pl1;
            }
            else 
            {
                Console.WriteLine("Spot is Taken");
                Player_One();
            }
        }
    }

    public static void Player_Two()
    {
        Game.currentplayer = pl2;
        Console.WriteLine("Player Two: Please select a number 1 to 9: ");
        int userturn = Convert.ToInt32(Console.ReadLine());
        userturn = userturn - 1;

        Game.turn = 2;

        if (userturn > 8 | userturn < 0)
        {
            Console.WriteLine("Number is not 1 - 9");
            Player_Two();
        }
        else 
        {
            if (game_board[userturn] = emty)
            {
                game_board[userturn] = pl2;
            }
            else
            {
                Console.WriteLine("Spot is Taken");
                Player_Two();
            }
        }
    }
}