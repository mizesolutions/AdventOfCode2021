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
        private int M { get; set; }
        private int N { get; set; }

        public Day09(string day, bool hasInput) : base(day, hasInput)
        {
            PrintCurrentClass();
            CaveMap = new();
            foreach (var s in FileInput)
            {
                char[] ch = s.ToCharArray();
                int[] t = Array.ConvertAll(ch, c => (int)Char.GetNumericValue(c));
                CaveMap.Add(t);
            }
            M = CaveMap[0].Length;
            N = CaveMap.Count;
            MapTheCave(CaveMap, 0, 0);
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

        private int MapTheCave(List<int[]> cave, int row, int col)
        {
            if (col >= M)
                return 0;
            if (row >= N)
                return 1;
            int val = cave[row][col];
            Result1 += MapPosition(cave[row][col], row, col);
            
            return MapTheCave(cave, row, col + 1) == 1 ? 1 : MapTheCave(cave, row + 1, 0);
        }

        private int MapPosition(int pos, int row, int col)
        {
            int up = -1;
            int right = -1;
            int down = -1;
            int left = -1;
            if(row - 1 >= 0)
            {
                up = CaveMap[row - 1][col];
            }
            if (col + 1 < M)
            {
                right = CaveMap[row][col + 1];
            }
            if (row + 1 < N) 
            {
                down = CaveMap[row + 1][col];
            }
            if (col - 1 >= 0)
            {
                left = CaveMap[row][col - 1];
            }

            if(up < -1 && left < -1)
            {
                return pos < right && pos < down ? pos + 1 : 0;
            }
            else if(up < -1 && right < -1)
            {
                return pos < left && pos < down ? pos + 1 : 0;
            }
            else if (down < -1 && left < -1)
            {
                return pos < right && pos < up ? pos + 1 : 0;
            }
            else if (down < -1 && right < -1)
            {
                return pos < left && pos < up ? pos + 1 : 0;
            }
            else if (up < -1)
            {
                return pos < right && pos < left && pos < down ? pos + 1 : 0;
            }
            else if (down < -1)
            {
                return pos < right && pos < left && pos < up ? pos + 1 : 0;
            }
            else if (left < -1)
            {
                return pos < down && pos < right && pos < up ? pos + 1 : 0;
            }
            else if (right < -1)
            {
                return pos < down && pos < left && pos < up ? pos + 1 : 0;
            }
            else
            {
                return pos < up && pos < right && pos < down && pos < left ? pos + 1 : 0;
            }

        }
    }
}
