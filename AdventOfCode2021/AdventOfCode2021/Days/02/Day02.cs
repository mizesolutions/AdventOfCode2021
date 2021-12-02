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
        private int Xposition { get; set; }
        private int Yposition { get; set; }
        private int Aim { get; set; }

        public Day02(string day, bool hasInput) : base(day, hasInput)
        {
            PrintCurrentClass();
            Xposition = 0;
            Yposition = 0;
            Aim = 0;
            PuzzleOne();
            PuzzleTwo();
        }

        private void PuzzleOne()
        {
            PrintCurrentMethod();
            foreach (var s in Input.Output)
            {
                var split = s.Split(" ");
                switch (split[0])
                {
                    case "forward":
                        Xposition += int.Parse(split[1]);
                        break;
                    case "down":
                        Yposition += int.Parse(split[1]);
                        break;
                    case "up": 
                        Yposition -= int.Parse(split[1]);
                        break;
                    default:
                        break;
                }
            }
            Result = Xposition * Yposition;
            PrintResults();
        }

        private void PuzzleTwo()
        {
            PrintCurrentMethod();
            Result = 0;
            Xposition = 0;
            Yposition = 0;
            Aim = 0;
            foreach (var s in Input.Output)
            {
                var split = s.Split(" ");
                switch (split[0])
                {
                    case "forward":
                        Xposition += int.Parse(split[1]);
                        Yposition += Aim * int.Parse(split[1]);
                        break;
                    case "down":
                        Aim += int.Parse(split[1]);
                        break;
                    case "up":
                        Aim -= int.Parse(split[1]);
                        break;
                    default:
                        break;
                }
            }
            Result = Xposition * Yposition;
            PrintResults();
        }
    }
}
