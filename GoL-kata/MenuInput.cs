using System;
using System.Collections.Generic;
using System.Threading;

namespace GoL_kata
{
    class MenuInput : IInput
    {
        public InputData ReadUserInput()
        {
            Console.WriteLine("================ MENU ================");
            Console.WriteLine("Which pattern would you like to input?");
            
            foreach (var item in _nameDictionary)
            {
                Console.WriteLine("[{0}]: {1}", item.Key, item.Value);
            }
            Console.WriteLine();
            
            var found = false;
            string seedName = "null";
            InputData input = new InputData();

            Console.Write("Please select an option...  ");
            
            while (!found)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                
                while (!_keyDictionary.ContainsKey(key))
                {
                    key = Console.ReadKey(true).Key;
                }
                seedName = _nameDictionary[_keyDictionary[key]];

                if (_dataDictionary.ContainsKey(seedName))
                {
                    input = _dataDictionary[seedName];
                    found = true;
                }
            }

            Console.WriteLine("\nYou have chosen the " + seedName + " as your pattern.");
            Thread.Sleep(1000);
            
            return input;
        }

        readonly Dictionary<ConsoleKey, string> _keyDictionary = new Dictionary<ConsoleKey, string>()
        {
            { ConsoleKey.A, "A" },
            { ConsoleKey.B, "B" },
            { ConsoleKey.C, "C" },
            { ConsoleKey.D, "D" },
            { ConsoleKey.E, "E" },
            { ConsoleKey.F, "F" },
            { ConsoleKey.G, "G" }
        };

        readonly Dictionary<string, string> _nameDictionary = new Dictionary<string, string>()
        {
            { "A", "Beehive" },
            { "B", "Blinker" },
            { "C", "Beacon" },
            { "D", "Pulsar" },
            { "E", "Penta-decathlon" },
            { "F", "Glider" },
            { "G", "Middle-weight spaceship"}
        };

        readonly Dictionary<string, InputData> _dataDictionary = new Dictionary<string, InputData>()
        {
            { "Beehive", new InputData {
                boardHeight = 5, boardWidth = 6, seedHeight = 3, seedWidth = 4, seedString = new[] {"-XX-", "X--X", "-XX-"}
            } },
            { "Blinker", new InputData
            {
                boardHeight = 5, boardWidth = 5, seedHeight = 3, seedWidth = 3, seedString = new[] {"---", "XXX", "---"}
            } },
            { "Beacon", new InputData
            {
                boardHeight = 6, boardWidth = 6, seedHeight = 4, seedWidth = 4, seedString = new[] {"XX--", "XX--", "--XX", "--XX"}
            } },
            { "Pulsar", new InputData
            {
                boardHeight = 17, boardWidth = 17, seedHeight = 13, seedWidth = 13, 
                seedString = new[] {
                    "--XXX---XXX--", "-------------", "X----X-X----X", "X----X-X----X", "X----X-X----X", "--XXX---XXX--", "-------------",
                    "--XXX---XXX--", "X----X-X----X", "X----X-X----X", "X----X-X----X", "-------------", "--XXX---XXX--"
                }
            } },
            { "Penta-decathlon", new InputData
            {
                boardHeight = 11, boardWidth = 18, seedHeight = 3, seedWidth = 10, seedString = new[] {"--X----X--", "XX-XXXX-XX", "--X----X--"}
            } },
            { "Glider", new InputData
            {
                boardHeight = 20, boardWidth = 20, seedHeight = 3, seedWidth = 3, seedString = new[] {"-X-", "--X", "XXX"}
            } },
            { "Middle-weight spaceship", new InputData
            {
                boardHeight = 11, boardWidth = 25, seedHeight = 5, seedWidth = 6, seedString = new[] {"--X---", "X---X-", "-----X", "X----X", "-XXXXX"}
            } }
        };
    }
}