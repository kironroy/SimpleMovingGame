
// https://www.youtube.com/watch?v=ZD-QOSswwDI

namespace SimpleMovingGame
{


    public class Program
    {
        // main game

        static void Main()
        {
            // intro
            GameStart.GameOverinBlue();

            // MAIN GAME RUN
            Main_GameRun.RunTheGame();     

            // gameover scene
            GameOver.GameOverinRed(); 
        }

    }
}

