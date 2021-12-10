using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Days
{
    class Day08 : BaseDay
    {
        private string[] Segment2Map { get; set; }
        private string[] Segment1Map { get; set; }
        private int Segment2Sum { get; set; }

        public Day08(string day, bool hasInput) : base(day, hasInput)
        {
            PrintCurrentClass();
            foreach (var l in FileInput)
            {
                var temp = l.Split(" | ").ToList();
                var p1 = temp[1].Split(" ").ToList();
                Segment2Map = new string[4];
                Segment1Map = new string[10];
                int seg2Index = 0;
                foreach (var s in p1)
                {
                    string os = string.Concat(s.OrderBy(c => c));
                    Segment2Map[seg2Index] = os;
                    seg2Index++;
                    switch (s.Length)
                    {
                        case 2:   // Its a 1
                            Segment1Map[1] = os;
                            Result1++;
                            break;
                        case 3:   // Its a 7
                            Segment1Map[7] = os;
                            Result1++;
                            break;
                        case 4:   // Its a 4
                            Segment1Map[4] = os;
                            Result1++;
                            break;
                        case 7:   // Its an 8
                            Segment1Map[8] = os;
                            Result1++;
                            break;
                    }
                }
                var p2 = temp[0].Split(" ").OrderBy(s => s.Length).ToList();
                // Map 1, 4, 7, and 8 if not mapped
                if (string.IsNullOrEmpty(Segment1Map[1]))
                {
                    Segment1Map[1] = string.Concat(p2[0].OrderBy(c => c));
                }
                if (string.IsNullOrEmpty(Segment1Map[4]))
                {
                    Segment1Map[4] = string.Concat(p2[2].OrderBy(c => c));
                }
                if (string.IsNullOrEmpty(Segment1Map[7]))
                {
                    Segment1Map[7] = string.Concat(p2[1].OrderBy(c => c));
                }
                if (string.IsNullOrEmpty(Segment1Map[8]))
                {
                    Segment1Map[8] = string.Concat(p2[9].OrderBy(c => c));
                }
                foreach (var s in p2)
                {
                    string os = string.Concat(s.OrderBy(c => c));
                    if (os.Length == 5)  // Its a 2, 3, or 5
                    {
                        if (os.Contains(Segment1Map[1][0]) && os.Contains(Segment1Map[1][1])) // Its a 3
                        {
                            Segment1Map[3] = os;
                        }
                        else if (os.Contains(Segment1Map[1][1])) // Its a 5
                        {
                            Segment1Map[5] = os;
                        }
                        else    // Its a 2
                        {
                            Segment1Map[2] = os;
                        }
                    }
                    else if (os.Length == 6)  // Its a 0, 6, or 9
                    {
                        if (os.Contains(Segment1Map[4][0]) && os.Contains(Segment1Map[4][1]) && os.Contains(Segment1Map[4][2]) && os.Contains(Segment1Map[4][3])) 
                        {
                            Segment1Map[9] = os;   // Its a 9
                        }
                        else if (os.Contains(Segment1Map[5][0]) && os.Contains(Segment1Map[5][1]) && os.Contains(Segment1Map[5][2]) && os.Contains(Segment1Map[5][3]) && os.Contains(Segment1Map[5][4]))
                        {
                            Segment1Map[6] = os;   // Its a 6
                        }
                        else
                        {
                            Segment1Map[0] = os;   // Its a 0
                        }
                    }
                }
                int place = 1000;
                Segment2Sum = 0;
                for (int i = 0; i < Segment2Map.Length; i++)
                {
                    Segment2Sum += Array.IndexOf(Segment1Map, Segment2Map[i])*place;
                    place = place / 10;
                }
                Result2 += Segment2Sum;
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
