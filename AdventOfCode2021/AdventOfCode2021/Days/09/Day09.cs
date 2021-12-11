using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Days
{
    class Day09 : BaseDay
    {
        private List<int[]> CaveMap { get; set; }

        public Day09(string day, bool hasInput) : base(day, hasInput)
        {
            PrintCurrentClass();
            CaveMap = new();
            foreach (var s in FileInput)
            {
                int[] t = s.Select(n => Convert.ToInt32(n)).ToArray();
                CaveMap.Add(t);
            }
            for(int i = 0, j = 0; i < CaveMap.Count; i++)
            {
                if(i == 0)
                {
                    if(j == 0)
                    {
                        if(CaveMap[i][j] - CaveMap[i][j+1] > 0)
                        {

                        }
                    }
                }
            }
            PuzzleOne();
            PuzzleTwo();
        }

        private void PuzzleOne()
        {
            PrintCurrentMethod();

            PrintResults(Result1);

        }

        private void PuzzleTwo()
        {
            PrintCurrentMethod();

            PrintResults(Result2);
        }
    }
}
