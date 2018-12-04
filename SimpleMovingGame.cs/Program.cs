using System;
using System.IO;

namespace SimpleMovingGame.cs
{
   
  class Program
    {
        
        // variables
        static int playerPosX = 1, playerPosY = 1;
        static int length = 4, height = 2; // instantion on 1 line
        static char player = '*', space = '-';

        // main game
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            while (true)
            {
                
                Draw();

                ConsoleKeyInfo keyPressed = Console.ReadKey();

                if((keyPressed.Key == ConsoleKey.W  && playerPosY != 1) || (keyPressed.Key == ConsoleKey.S && playerPosX != length))
                {
                    playerPosY += (keyPressed.Key == ConsoleKey.S) ? 1 : -1;
                }

                if ((keyPressed.Key == ConsoleKey.A && playerPosX != 1) || (keyPressed.Key == ConsoleKey.D && playerPosY != length))
                {
                    playerPosX += (keyPressed.Key == ConsoleKey.D) ? 1 : -1;
                }

               


            }
        }

        // draw the game
        static void Draw()
        {
            Console.Clear();

            Console.Write($"{playerPosX}, {playerPosY}\n");
            Console.WriteLine(); // breakline

            for (int y = 1; y <= height; ++y)
            {
                for (int x = 1; x <= length; ++x)
                {
                    if (x == playerPosX && y == playerPosY) Console.Write(player);
                    else Console.Write(space);
                }
                Console.WriteLine();
            }

            
        }
    }
}
