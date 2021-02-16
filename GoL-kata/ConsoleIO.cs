using System;

// COMPLETE. Controls the connecting of IO sources.

namespace GoL_kata
{
    static class ConsoleIO
    {
        private static IInput _inputSystem;
        
        public static IInput GetUserSelectInputType()
        {
            Console.WriteLine("How would you like to play?");
            Console.WriteLine("\t[A] Enter your own seed");
            Console.WriteLine("\t[B] Select a cool seed");
            Console.WriteLine("\t[C] Generate a random seed\n");
            
            Console.Write("Please select an option...  ");

            var key = Console.ReadKey(true).Key;

            while (key != ConsoleKey.A && key != ConsoleKey.B && key != ConsoleKey.C)
            {
                key = Console.ReadKey(true).Key;
            }

            var type = "default";
            
            switch (key)
            {
                case ConsoleKey.A:
                    _inputSystem = new UserInput();
                    type = "Manual Input";
                    break;
                case ConsoleKey.B:
                    _inputSystem = new MenuInput();
                    type = "Menu Input";
                    break;
                case ConsoleKey.C:
                    _inputSystem = new RandomInput();
                    type = "Random Input";
                    break;
            }

            Console.WriteLine("\nYou have chosen " + type + "\n");
            return _inputSystem;
        }
        
        public static void PrintGameBoard(Board board, int iteration)
        {
            Console.WriteLine("\n\nGame Tick: " + iteration + "\n");
            for (int i = 0; i < board.BoardHeight; i++)
            {
                var activeCount = 0;
                for (int j = 0; j < board.BoardWidth; j++)
                {
                    if (board.CellArray[i, j].active)
                    {
                        if (board.CellArray[i, j].alive)
                        {
                            Console.Write("■ ");
                        }
                        else
                        {
                            Console.Write("□ ");
                        }

                        activeCount++;
                    }
                }
                if (activeCount > 0) Console.Write("\n");
            }
        }
    }
}