using AdventOfCode2021.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            PuzzleOne(IntInput);
            Console.WriteLine("Puzzle Two:");
            PuzzleTwo();
        }

        private void PuzzleOne(List<int> list)
        {
            for (var i = 0; i <= list.Count - 2; i++)
            {
                int j = i + 1;
                if (list.ElementAt(j) > list.ElementAt(i))
                {
                    Count++;
                }
            }
            Console.WriteLine($"Result: {Count}\r\n\r\n");
        }

        private void PuzzleTwo()
        {
            var sumList = new List<int>();
            Count = 0;
            for(var i = 0; i <= IntInput.Count - 3; i++)
            {
                sumList.Add(IntInput.ElementAt(i) + IntInput.ElementAt(i+1) + IntInput.ElementAt(i+2));
            }
            PuzzleOne(sumList);
        }
    }
}
