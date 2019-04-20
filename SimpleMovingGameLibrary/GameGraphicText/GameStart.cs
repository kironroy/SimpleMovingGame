using System;


namespace SimpleMovingGame
{
    public static class GameStart
    {
        public static void TypeWritter(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                System.Threading.Thread.Sleep(2);

            }

        }
        public static void GameOverinBlue()
        {

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Title = "ASCII Art";
            Console.WriteLine(); // breakline
            string titleBlue =
                 @"
                                       
                           


                             _    _      _                          
                            | |  | |    | |                         
                            | |  | | ___| | ___ ___  _ __ ___   ___ 
                            | |/\| |/ _ \ |/ __/ _ \| '_ ` _ \ / _ \
                            \  /\  /  __/ | (_| (_) | | | | | |  __/
                             \/  \/ \___|_|\___\___/|_| |_| |_|\___|
                                        
                                        



                  ";

            TypeWritter(titleBlue);
            Console.WriteLine(); // breakline

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Make sure the enemy does not catch you!");
            Console.WriteLine();
            Console.WriteLine("  Press A to move left, \n  D to move right, \n  S to move down, \n  W to move up  ");
            Console.WriteLine();
            Console.WriteLine(" Press any key to begin");
            Console.ReadKey();
            Console.Clear();

        } // method end


    }
}
