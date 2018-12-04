﻿using System;


namespace SimpleMovingGame
{
    public static class GameRun
    {
        // variables
        static int playerPosX = 1, playerPosY = 1; // instantion on 1 line
        static int enemyPosX = length;
        static int enemyPosY = height;
        static int length = 10, height = 10;
        static string player = " *", space = " |", enemy = " $";
        static Random random = new Random();

        // main game
        public static void RunTheGame()
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            while (true)
            {

                Draw();
                if (playerCollideWithEnemy()) break;




                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;

                ConsoleKeyInfo keyPressed = Console.ReadKey();

                if ((keyPressed.Key == ConsoleKey.W && playerPosY != 1) || (keyPressed.Key == ConsoleKey.S && playerPosY != height))
                {
                    playerPosY += (keyPressed.Key == ConsoleKey.S) ? 1 : -1;
                }

                if ((keyPressed.Key == ConsoleKey.A && playerPosX != 1) || (keyPressed.Key == ConsoleKey.D && playerPosX != length))
                {
                    playerPosX += (keyPressed.Key == ConsoleKey.D) ? 1 : -1;
                }
                moveEnemey();

            }


        }

        static void moveEnemey()
        {
            if (random.Next(0, 11) > 5 && playerPosX != enemyPosX) // X
            {
                if (playerPosX < enemyPosX) --enemyPosX;
                else if (playerPosX > enemyPosX) ++enemyPosX;
            }
            else // Y
            {
                if (playerPosY < enemyPosY) --enemyPosY;
                else if (playerPosY > enemyPosY) ++enemyPosY;
            }
        }

        // check if enemy has caught the player

        static bool playerCollideWithEnemy()
        {
            if (playerPosX == enemyPosX && playerPosY == enemyPosY) return true;
            return false;
        }

        // draw the game
        static void Draw()
        {
            Console.Clear();
            Console.WriteLine($"          {playerPosX}, {playerPosY}\n");
            Console.WriteLine($"          {enemyPosX}, {enemyPosY}\n");
            Console.WriteLine(); // breakline

            for (int y = 1; y <= height; ++y)
            {
                for (int x = 1; x <= length; ++x)
                {
                    if (x == playerPosX && y == playerPosY) Console.Write(player);
                    else if (x == enemyPosX && y == enemyPosY) Console.Write(enemy);
                    else Console.Write(space);
                }
                Console.WriteLine();
            }




        }


    }
}

// GameOver.GameOverinRed();