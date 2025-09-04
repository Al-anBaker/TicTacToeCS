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
    

    //This code initalises the varibles and makes the Game_board
    public static void Main()
    {
        Game.turn = 0;
        Game.gameover = false;
        for (int i = 0; i < Game.game_board.Length; i++)
        {
            Game.game_board[i] = emty;
        }
        //We ask and save what symbol the 1st player wants
        Console.WriteLine("Player One: Please input your letter or number you want to use: ");
        Game.pl1 = Console.ReadLine();
        //This saves the 1st Player symbol in an array of current players at the 0th posiition
        Game.players[0] = pl1;
        // We ask and save what symbol the 2nd player wants
        Console.WriteLine("Player Two: Please input your letter or number you want to use: ");
        Game.pl2 = Console.ReadLine();
        //This saves the 2nd Player Symbol in an array of current players at the 1st position
        Game.players[1] = pl2;



        Game_Loop();
    }
    //This is where we draw the gameboard, it writes each line of the board at a time with spacers inbetween each, the numbers on the side helps the players
    //see what key the need to press
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
    //This is the first Win Condition check, it checks to see if any of the rows have a matching player symbol in all three in a row
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
    //This is the second Win Condition check, it checks to see if each player has a matching 3 in any collum
    public static void Check_Collums()
    {

        if ((game_board[0] == currentplayer) && (game_board[3] == currentplayer) && (game_board[6] == currentplayer) || 
            (game_board[1] == currentplayer) && (game_board[4] == currentplayer) && (game_board[7] == currentplayer) ||
            (game_board[2] == currentplayer) && (game_board[5] == currentplayer) && (game_board[8] == currentplayer)) {
            Game.gameover = true;
            Win_Check();
        }
    }

    // Then for the third check we check to see of any players have a matching 3 in any diaginol
    public static void Check_Diags()
    {


        if ((game_board[0] == currentplayer) && (game_board[4] == currentplayer) && (game_board[8] == currentplayer) || 
            (game_board[2] == currentplayer) && (game_board[4] == currentplayer) && (game_board[6] == currentplayer)) 
            {
            Game.gameover = true;
            Win_Check();
        }
    }
    //If the first 3 checks fail then we check if there is a tie, where no two players can win
    public static void Check_Tie()
    {
       if (!Array.Exists(game_board, element => element == emty))
       {
        turn = 3;
        gameover = true;
        Win_Check();
       }
    }
    // At the end of Win check we see whos turn it was and Write to the console who won and to game over, then re reinitalise the game
    public static void Game_Over()
    {
        if (Game.turn == 1)
        {
            Draw_Game();
            Console.WriteLine("Player One Wins!");
            Console.WriteLine("Game Over!");
            Play_Again();
        }
        else if (Game.turn == 2)
        {
            Draw_Game();
            Console.WriteLine("Player Two Wins!");
            Console.WriteLine("Game Over!");
            Play_Again();
        }
        //Game Turn can only be 3 if there was a tie
        else if (Game.turn == 3)
        {
            Draw_Game();
            Console.WriteLine("Tie!");
            Console.WriteLine("Game Over!");
            Play_Again();
        }
    }
    //Win Check basically just runs an if statement to see if the gameover varible has been flipped to true
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
    //This lists the order of checks for a win, starting with rows, then Collums, then Diags and if all those pass then go to tie
    public static void Checks()
    {
        Check_Rows();
        Check_Collums();
        Check_Diags();
        Check_Tie();
    }
    //This is the main Game Loop, all it does is call the other methods aand define, what method is called when
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
    //This is the 1st Players turn it sets the current player to pl1 for the win checks, then asks to pick a number 1-9
    public static void Player_One()
    {
        Game.currentplayer = pl1;
        Console.WriteLine("Player One: Please select a number 1 to 9: ");
        int userturn = Convert.ToInt32(Console.ReadLine());
        userturn = userturn - 1;
        Game.turn = 1;
        //If the player selcts a number outside the bounds of the game, it return to the start of their turn and asks them to pick another number
        if (userturn > 8 | userturn < 0)
        {
            Console.WriteLine("Selection is not 1-9");
            Player_One();
        }
        else 
        {
            //If the player picked spot is already taken then restart players turn with message Spot is Taken
            if (game_board[userturn] == emty)
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
    // Works the same as Player One, just with Player One swapped with the Player 2 varibles
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
            if (game_board[userturn] == emty)
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