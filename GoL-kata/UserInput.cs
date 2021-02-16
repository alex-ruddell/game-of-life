using System;
using System.Text.RegularExpressions;

// COMPLETE. Deals with custom user inputs.

namespace GoL_kata
{
    class UserInput : IInput
    {
        private static InputData _input;
        
        // TODO: a BIG bunch of error handling!

        public InputData ReadUserInput()
        {
            Console.Write("Please enter an integer board height (# cells):  ");
            _input.boardHeight = Int32.Parse(Console.ReadLine());
            Console.Write("Please enter an integer board width  (# cells):  ");
            _input.boardWidth = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\nPlease set the initial state of the board. You may enter any shape you want!");
            Console.WriteLine("For example:\n\t\t----XXXX----\t  \t---XX--XX---\n\t\t--XXX-XXX---\tOR\tXX--------XX" +
                              "\n\t\t-X-XXXX-XX--\t  \t--XXXXXXXX--");

            Console.WriteLine("\nWhere 'X' characters mark live cells, and '-' characters mark dead ones");

            Console.Write("\nPlease enter a seed height:  ");
            _input.seedHeight = Int32.Parse(Console.ReadLine());
            Console.Write("Please enter a seed width :  ");
            _input.seedWidth = Int32.Parse(Console.ReadLine());
            // TODO: validate that these are less than the board sizes

            Console.WriteLine("\nPlease enter your seed line by line...\n");
            Console.Write("Cols  | ");
            for (var col = 1; col <= _input.seedWidth; col++)
            {
                Console.Write(col.ToString());
            }
            Console.Write("\n");
            // TODO: print columns better when they have two numbers...

            _input.seedString = new string[_input.seedHeight];
            var regex = new Regex(@"[-X]");

            for (var row = 1; row <= _input.seedHeight; row++)
            {
                Console.Write("Row " + row + " | ");
                var inputLine = Console.ReadLine();
                MatchCollection matches = regex.Matches(inputLine);

                if (matches.Count != inputLine.Length)
                {
                    Console.WriteLine("Please only enter '-' or 'X' characters.");
                    row--;
                }
                else
                {
                    _input.seedString[row - 1] = inputLine;
                }
            }
            // TODO: validate that these are the right length / fill in any gaps

            Console.WriteLine("\nYour seed is...\n");

            foreach (string line in _input.seedString)
            {
                Console.WriteLine("\t\t" + line);
            }
            
            Console.Write("\n\nWould you like the board to [W]rap, or have [F]ixed edges?  ");
            
            ConsoleKey key = Console.ReadKey(true).Key;
            while (key != ConsoleKey.F && key != ConsoleKey.W)
            {
                key = Console.ReadKey(true).Key;
            }

            var type = "default";
            switch (key)
            {
                case ConsoleKey.F:
                    _input.boardType = "Fixed";
                    type = "fixed edge";
                    break;
                case ConsoleKey.W:
                    _input.boardType = "Wrap";
                    type = "wrap";
                    break;
            }

            Console.WriteLine("\nYou have chosen a " + type + " board");

            return _input;
        }

    }
}