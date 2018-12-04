using System;


namespace SimpleMovingGame
{
    public static class Main_GameRun
    {
        // variables
        static int playerPosX = 1, playerPosY = 1; // instantion on 1 line
        static int enemyPosX, enemyPosY;
        static int itemPosX, itemPosY;
        static int score; 
        static int length = 10, height = 10;
        static string player = " *", space = " |", enemy = " @", item = " $";
        static Random random = new Random();

        // main game
        public static void RunTheGame()
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            enemyPosX = length;
            enemyPosY = height;
            createItem();

            while (true)
            {

                Draw();
                Console.WriteLine();
                Console.WriteLine($" Score: {score}");
                if (playerCollideWithEnemy()) break;
                if (playerCollideWithItem())
                {
                    ++score;
                    createItem();
                }


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
            if (random.Next(0, 11) < 3) return;
            if (random.Next(0, 11) > 5 && playerPosX != enemyPosX || playerPosY == enemyPosY) // X
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

        // check if the player has collected an item

        static bool playerCollideWithItem()
        {
            if (playerPosX == itemPosX && playerPosY == itemPosY) return true;
            return false;
        }

        // create a new item

        static void createItem()
        {
            int itemX = random.Next(1, length + 1), itemY = playerPosY;

            while (itemY > playerPosY - 2 && itemY < playerPosY + 2)
            {
                itemY = random.Next(1, height);
            }

            itemPosX = itemX;
            itemPosY = itemY;
        }

        // draw the game
        static void Draw()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($" Player's position {playerPosX}, {playerPosY}");
            Console.WriteLine($" Enemy's position  {enemyPosX}, {enemyPosY}");
            Console.WriteLine(); // breakline

            for (int y = 1; y <= height; ++y)
            {
                for (int x = 1; x <= length; ++x)
                {
                    if (x == playerPosX && y == playerPosY) Console.Write(player);
                    else if (x == enemyPosX && y == enemyPosY) Console.Write(enemy);
                    else if (x == itemPosX && y == itemPosY) Console.Write(item);
                    else Console.Write(space);
                }
                Console.WriteLine();
            }




        }


    }
}

// GameOver.GameOverinRed();