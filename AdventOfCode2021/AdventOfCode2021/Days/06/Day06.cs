using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Days
{
    class Day06 : BaseDay
    {
        private List<int> FishCount { get; set; }
        private List<int> AddFish { get; set; }

        public Day06(string day, bool hasInput) : base(day, hasInput)
        {
            PrintCurrentClass();
            FishCount = FileInput.FirstOrDefault().Split(",").Select(int.Parse).ToList();
            AddFish = new();
            PuzzleOne();
            PuzzleTwo();
        }

        private void PuzzleOne()
        {
            PrintCurrentMethod();
            //PrintFish(0, true);
            for (int day = 1; day <= 80; day++)
            {
                AddFish = new();
                for(int f = 0; f < FishCount.Count; f++)
                {
                    FishCount[f] -= 1;
                    if(FishCount[f] == -1)
                    {
                        FishCount[f] = 6;
                        AddFish.Add(8);
                    }
                }
                FishCount = FishCount.Concat(AddFish).ToList();
                //PrintFish(0, true);
                if (day == 80)
                {
                    Result1 = FishCount.Count();
                    PrintResults(Result1);
                }
            }
            Result2 = FishCount.Count();
            
        }

        private void PuzzleTwo()
        {
            PrintCurrentMethod();

            PrintResults(Result2);
        }

        private void PrintFish(int day, bool flag = false)
        {
            Console.Write($"\r\nDay {day}:  ");
            if (flag)
            {
                foreach (var f in FishCount)
                {
                    Console.Write($"{f}, ");
                }
            }
            else
            {
                Console.Write($"{FishCount.Count}");
            }
            
        }

    }
}
