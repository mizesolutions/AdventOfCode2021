using AdventOfCode2021.Days._00;
using AdventOfCode2021.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Days._02
{
    public class Day02 : BaseDay
    {
        public Day02(string day, bool hasInput) : base(day, hasInput)
        {
            Console.WriteLine(GetCurrentClass());

            PuzzleOne();
            PuzzleTwo();
        }

        private void PuzzleOne()
        {
            Console.WriteLine(GetCurrentMethod());

            Console.WriteLine(GetResults());
        }

        private void PuzzleTwo()
        {
            Console.WriteLine(GetCurrentMethod());

            Console.WriteLine(GetResults());
        }
    }
}
