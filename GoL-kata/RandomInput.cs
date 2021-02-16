using System;
using System.Linq;

namespace GoL_kata
{
    class RandomInput : IInput
    {
        public InputData ReadUserInput()
        {
            var input = new InputData();
            var r = new Random();

            input.seedHeight = r.Next(1, 10);
            input.seedWidth = r.Next(1, 10);
            input.seedString = new string[input.seedHeight];

            for (int i = 0; i < input.seedHeight; i++)
            {
                string line = "";
                
                for (int j = 0; j < input.seedWidth; j++)
                {
                    double num = r.Next(0, 100);
                    var round = Math.Round(num / 100);

                    if (round == 1)
                    {
                        line = String.Concat(line, "X");
                    }
                    else
                    {
                        line = String.Concat(line, "-");
                    }
                    
                }
                
                input.seedString[i] = line;
            }

            input.boardHeight = 25;
            input.boardWidth = 25;

            return input;
        }
    }
}