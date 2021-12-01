using AdventOfCode2021.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.Days._01
{
    public class Day01
    {
        public RenderInput Input { get; set; }
        private int Count { get; set; }
        private List<int> IntInput { get; set; }

        public Day01(string day, bool isInput)
        {
            if (isInput)
            {
                try
                {
                    Input = new RenderInput(day);
                    IntInput = Input.ToInt();
                }
                catch (FileNotFoundException fe)
                {
                    Console.WriteLine(fe);
                }
            }
            Console.WriteLine("Puzzle One:");
            PuzzleOne();
            Console.WriteLine("Puzzle Two:");
            PuzzleTwo();
        }

        private void PuzzleOne()
        {
            for (var i = 0; i <= IntInput.Count - 2; i++)
            {
                int j = i + 1;
                if (IntInput.ElementAt(j) > IntInput.ElementAt(i))
                {
                    Count++;
                }
            }
            Console.WriteLine($"Result: {Count}\r\n\r\n");
        }

        private void PuzzleTwo()
        {
            Count = 0;
            for (int i = 0, j = i + 1; j <= IntInput.Count - 3; i++, j++)
            {
                if ((IntInput.ElementAt(j) + IntInput.ElementAt(j + 1) + IntInput.ElementAt(j + 2)) > (IntInput.ElementAt(i) + IntInput.ElementAt(i + 1) + IntInput.ElementAt(i + 2)))
                {
                    Count++;
                }
            }
            Console.WriteLine($"Result: {Count}\r\n\r\n");
        }
    }
}
