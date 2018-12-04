using System;


namespace SimpleMovingGame
{
    public static class GameOver
    {
        public static void typeWritter(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                System.Threading.Thread.Sleep(2);

            }

        }
        public static void GameOverinRed()
        {

            Console.ForegroundColor = ConsoleColor.Red;

            Console.Title = "ASCII Art";
            Console.WriteLine(); // breakline
            string titleRed =
                 @"
                                       
                           

                  _______      ___      .___  ___.  _______   ______   ____    ____  _______ .______      
                 /  _____|    /   \     |   \/   | |   ____| /  __  \  \   \  /   / |   ____||   _  \     
                |  |  __     /  ^  \    |  \  /  | |  |__   |  |  |  |  \   \/   /  |  |__   |  |_)  |    
                |  | |_ |   /  /_\  \   |  |\/|  | |   __|  |  |  |  |   \      /   |   __|  |      /     
                |  |__| |  /  _____  \  |  |  |  | |  |____ |  `--'  |    \    /    |  |____ |  |\  \----.
                 \______| /__/     \__\ |__|  |__| |_______| \______/      \__/     |_______|| _| `._____|
                                                                                          
  

               ";

            typeWritter(titleRed);
            Console.WriteLine(); // breakline
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" -- Press enter twice to exit --");
            Console.ReadKey();
            Console.Clear();

        } // method end


    }
}
