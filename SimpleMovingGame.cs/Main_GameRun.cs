using System;


namespace SimpleMovingGame
{
    public static class Main_GameRun
    {
        // variables
        static int playerPosX = 1, playerPosY = 1; // instantion on 1 line
        static int enemyPosX, enemyPosY;
        static int itemPosX, itemPosY;
        static int score, highScore;
        private static readonly int length = 10;
        private static int height = 10;
        private static readonly string player = " O";
        private static string space = " |";
        private static string enemy = " X";
        private static string item = " $";
        static Random random = new Random();

        private static int PlayerPosX { get => playerPosX; set => playerPosX = value; }
        private static int EnemyPosX { get => enemyPosX; set => enemyPosX = value; }
        private static int ItemPosX { get => itemPosX; set => itemPosX = value; }
        private static int Score { get => score; set => score = value; }

        // main game
        public static void RunTheGame()
        {
            bool playingGame = true;

            while (playingGame)
            {
                MainGamePlay(); // main game logic

                // game is over
                if (Score > highScore) highScore = Score;
                Console.WriteLine($" \n GAME OVER \n High Score: {highScore}");
                Console.Beep(3000, 50);
                Console.Beep(2500, 50);
                Console.Beep(3000, 50);
                Console.Beep(2000, 50);
                Console.Beep(3000, 50);
                Console.Beep(1500, 50);


                // check to restart to game

                Console.Write(" Do you want to play again? (Y/N): ");
                ConsoleKeyInfo keyPressed = Console.ReadKey();
                if (keyPressed.Key == ConsoleKey.N) playingGame = false;

            
            }
        }

        // play game
        static void MainGamePlay()
        {
           

            PlayerPosX = 1;
            playerPosY = 1;
            EnemyPosX = length;
            enemyPosY = height;
            CreateItem();

            while (true)
            {

                DrawGameboard();
                Console.WriteLine();
                Console.WriteLine($" Score: {Score}");
                if (PlayerCollideWithEnemy()) break;
                if (PlayerCollideWithItem())
                {
                    ++Score;
                    Console.Beep(3000, 50);
                    CreateItem();
                    DrawGameboard();
                }


                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;

                ConsoleKeyInfo keyPressed = Console.ReadKey();

                if ((keyPressed.Key == ConsoleKey.W && playerPosY != 1) || (keyPressed.Key == ConsoleKey.S && playerPosY != height))
                {
                    playerPosY += (keyPressed.Key == ConsoleKey.S) ? 1 : -1;
                }

                if ((keyPressed.Key == ConsoleKey.A && PlayerPosX != 1) || (keyPressed.Key == ConsoleKey.D && PlayerPosX != length))
                {
                    PlayerPosX += (keyPressed.Key == ConsoleKey.D) ? 1 : -1;
                }
                MoveEnemey();

            }
        }

        static void MoveEnemey()
        {
            if (random.Next(0, 11) < 3) return;
            if (random.Next(0, 11) > 5 && PlayerPosX != EnemyPosX || playerPosY == enemyPosY) // X
            {
                if (PlayerPosX < EnemyPosX) --EnemyPosX;
                else if (PlayerPosX > EnemyPosX) ++EnemyPosX;
            }
            else // Y
            {
                if (playerPosY < enemyPosY) --enemyPosY;
                else if (playerPosY > enemyPosY) ++enemyPosY;
            }
        }

        // check if enemy has caught the player

        static bool PlayerCollideWithEnemy()
        {
            if (PlayerPosX == EnemyPosX && playerPosY == enemyPosY) return true;
            return false;
            
        }

        // check if the player has collected an item

        static bool PlayerCollideWithItem()
        {
            if (PlayerPosX == ItemPosX && playerPosY == itemPosY) return true;
            return false;
        }

        // create a new item

        static void CreateItem()
        {
            int itemX = random.Next(1, length + 1), itemY = playerPosY;

            while (itemY > playerPosY - 2 && itemY < playerPosY + 2)
            {
                itemY = random.Next(1, height);
            }

            ItemPosX = itemX;
            itemPosY = itemY;
        }

        // draw the game
        static void DrawGameboard()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($" Player's position {PlayerPosX}, {playerPosY}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" Enemy's position  {EnemyPosX}, {enemyPosY}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(); // breakline

            for (int y = 1; y <= height; ++y)
            {
                for (int x = 1; x <= length; ++x)
                {
                    if (x == EnemyPosX && y == enemyPosY) Console.Write(enemy);
                    else if (x == PlayerPosX && y == playerPosY) Console.Write(player);
                    else if (x == ItemPosX && y == itemPosY) Console.Write(item);
                    else Console.Write(space);
                }
                Console.WriteLine();
            }




        }


    }
}

