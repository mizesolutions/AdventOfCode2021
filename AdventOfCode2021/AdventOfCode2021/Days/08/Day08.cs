using System;
using System.Linq;

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
                // Map the 6 segments first
                for(int i = 6; i < 9; i++)
                {
                    string os = string.Concat(p2[i].OrderBy(c => c));
                    if (!(os.Contains(Segment1Map[1][0]) && os.Contains(Segment1Map[1][1])))
                    {
                        Segment1Map[6] = os;   // Its a 6
                    }
                    else if (os.Contains(Segment1Map[4][0]) && os.Contains(Segment1Map[4][1]) && os.Contains(Segment1Map[4][2]) && os.Contains(Segment1Map[4][3]))
                    {
                        Segment1Map[9] = os;   // Its a 9
                    }
                    else
                    {
                        Segment1Map[0] = os;   // Its a 0
                    }
                }
                // Map the 5 segments
                for (int i = 3; i < 6; i++)
                {
                    string os = string.Concat(p2[i].OrderBy(c => c));
                    if (os.Contains(Segment1Map[1][0]) && os.Contains(Segment1Map[1][1])) // Its a 3
                    {
                        Segment1Map[3] = os;   // Its a 3
                    }
                    else if (Segment1Map[6].Contains(os[0]) && Segment1Map[6].Contains(os[1]) && Segment1Map[6].Contains(os[2]) && Segment1Map[6].Contains(os[3]) && Segment1Map[6].Contains(os[4]))
                    {
                        Segment1Map[5] = os;   // Its a 5
                    }
                    else    
                    {
                        Segment1Map[2] = os;   // Its a 2
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
