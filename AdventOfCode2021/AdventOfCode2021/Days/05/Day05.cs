using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Days
{
    class Day05 : BaseDay
    {
        public partial class Points
        {
            public int X1 { get; set; }
            public int Y1 { get; set; }
            public int X2 { get; set; }
            public int Y2 { get; set; }

            public Points(int x1, int y1, int x2, int y2)
            {
                X1 = x1;
                Y1 = y1;
                X2 = x2;
                Y2 = y2;
            }

            public override string ToString()
            {
                return $"{X1},{Y1} -> {X2},{Y2}";
            }
        }

        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public List<Points> LineList { get; set; }
        public List<Points> DiagLineList { get; set; }
        public int[,] Grid { get; set; }

        public Day05(string day, bool hasInput) : base(day, hasInput)
        {
            PrintCurrentClass();
            MaxX = 0;
            MaxY = 0;
            LineList = InputToLineList();
            DiagLineList = new();
            Grid = new int[MaxY+1, MaxX + 1];
            RunIt();
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

            PrintResults(Result2+Result1);
        }

        private void RunIt()
        {
            foreach (var p in LineList)
            {
                if (p.X1 == p.X2 || p.Y1 == p.Y2)
                {
                    if (p.X1 != p.X2)
                    {
                        if (p.X1 > p.X2)
                        {
                            for (int i = 0; i <= p.X1 - p.X2; i++)
                            {
                                Grid[p.Y1, p.X1 - i] += 1;
                                if (Grid[p.Y1, p.X1 - i] == 2)
                                {
                                    Result1 += 1;
                                }

                            }
                        }
                        else
                        {
                            for (int i = 0; i <= p.X2 - p.X1; i++)
                            {
                                Grid[p.Y1, p.X1 + i] += 1;
                                if (Grid[p.Y1, p.X1 + i] == 2)
                                {
                                    Result1 += 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (p.Y1 > p.Y2)
                        {
                            for (int i = 0; i <= p.Y1 - p.Y2; i++)
                            {
                                Grid[p.Y1 - i, p.X1] += 1;
                                if (Grid[p.Y1 - i, p.X1] == 2)
                                {
                                    Result1 += 1;
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i <= p.Y2 - p.Y1; i++)
                            {
                                Grid[p.Y1 + i, p.X1] += 1;
                                if (Grid[p.Y1 + i, p.X1] == 2)
                                {
                                    Result1 += 1;
                                }
                            }
                        }
                    }
                }
                else
                {
                    DiagLineList.Add(p);
                }
            }

            foreach(var p in DiagLineList)
            {
                if (p.X1 - p.X2 >= 0 && p.Y1 - p.Y2 >= 0)
                {
                    for (int x = 0, y = 0; x <= p.X1 - p.X2 || y <= p.Y1 - p.Y2; x++, y++)
                    {
                        Grid[p.Y1 - y, p.X1 - x] += 1;
                        if (Grid[p.Y1 - y, p.X1 - x] == 2)
                        {
                            Result2 += 1;
                        }
                    }
                }
                else if (p.X1 - p.X2 < 0 && p.Y1 - p.Y2 < 0)
                {
                    for (int x = 0, y = 0; x <= p.X2 - p.X1 || y <= p.Y2 - p.Y1; x++, y++)
                    {
                        Grid[p.Y1 + y, p.X1 + x] += 1;
                        if (Grid[p.Y1 + y, p.X1 + x] == 2)
                        {
                            Result2 += 1;
                        }
                    }
                }
                else if (p.X1 - p.X2 >= 0 && p.Y1 - p.Y2 < 0)
                {
                    for (int x = 0, y = 0; x <= p.X1 - p.X2 || y <= p.Y2 - p.Y1; x++, y++)
                    {
                        Grid[p.Y1 + y, p.X1 - x] += 1;
                        if (Grid[p.Y1 + y, p.X1 - x] == 2)
                        {
                            Result2 += 1;
                        }
                    }
                }
                else
                {
                    for (int x = 0, y = 0; x <= p.X2 - p.X1 || y <= p.Y1 - p.Y2; x++, y++)
                    {
                        Grid[p.Y1 - y, p.X1 + x] += 1;
                        if (Grid[p.Y1 - y, p.X1 + x] == 2)
                        {
                            Result2 += 1;
                        }
                    }
                }
            }
        }

        private List<Points> InputToLineList()
        {
            List<Points> result = new(FileInput.Count);

            foreach (var l in FileInput)
            {
                var temp = l.Replace(" -> ", ",").Split(",").Select(int.Parse).ToArray();

                var p = new Points(temp[0], temp[1], temp[2], temp[3]);
                result.Add(p);

                MaxX = MaxX > (temp[0] > temp[2] ? temp[0] : temp[2]) ? MaxX : (temp[0] > temp[2] ? temp[0] : temp[2]);
                MaxY = MaxY > (temp[1] > temp[3] ? temp[1] : temp[3]) ? MaxY : (temp[1] > temp[3] ? temp[1] : temp[3]);
            }
            return result;
        }
    }
}
