using System;

namespace GoL_kata
{
    class Program
    {
        private static IInput _inputSystem;
        private static Game _gameOfLife;
        
        static void Main(string[] args)
        {
            Initialise();
            
            _gameOfLife.Run();
        }

        static void Initialise()
        {
            Console.WriteLine("Welcome to Conway's Game of Life!\n");
            
            _inputSystem = ConsoleIO.GetUserSelectInputType();
            var userInput = _inputSystem.ReadUserInput();
            _gameOfLife = new Game(userInput);
            
        }
    }
}