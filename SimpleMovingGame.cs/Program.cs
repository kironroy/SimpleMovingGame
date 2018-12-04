namespace SimpleMovingGame
{


    public class Program
    {



        // main game
        static void Main()
        {
            // intro
            GameStart.GameOverinBlue();

            // game run main class
            GameRun.RunTheGame();     

            // gameover scene
            GameOver.GameOverinRed(); 
        }

    }
}

// GameOver.GameOverinRed();