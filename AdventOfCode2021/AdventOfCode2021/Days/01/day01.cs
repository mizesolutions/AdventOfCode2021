using AdventOfCode2021.Days._00;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Days._01
{
    public class Day01 : BaseDay
    {
        private List<int> IntInput { get; set; }

        public Day01(string day, bool hasInput) : base(day, hasInput)
        {
            Console.WriteLine(GetCurrentClass());
            IntInput = Input.ToInt();
            
            PuzzleOne();
            PuzzleTwo();
        }

        private void PuzzleOne()
        {
            Console.WriteLine(GetCurrentMethod());
            for (var i = 0; i <= IntInput.Count - 2; i++)
            {
                int j = i + 1;
                if (IntInput.ElementAt(j) > IntInput.ElementAt(i))
                {
                    Count++;
                }
            }
            Console.WriteLine(GetResults());
        }

        private void PuzzleTwo()
        {
            Console.WriteLine(GetCurrentMethod());
            Count = 0;
            for (int i = 0, j = i + 1; j <= IntInput.Count - 3; i++, j++)
            {
                if ((IntInput.ElementAt(j) + IntInput.ElementAt(j + 1) + IntInput.ElementAt(j + 2)) > (IntInput.ElementAt(i) + IntInput.ElementAt(i + 1) + IntInput.ElementAt(i + 2)))
                {
                    Count++;
                }
            }
            Console.WriteLine(GetResults());
        }
    }
}
