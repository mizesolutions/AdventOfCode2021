using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.Days
{
    class Day04 : BaseDay
    {
        private List<int> IntList { get; set; }
        private int[,] IntMatrix { get; set; }
        private List<int[,]> IntMatrixList { get; set; }

        public Day04(string day, bool hasInput) : base(day, hasInput)
        {
            PrintCurrentClass();
            IntList = new();
            IntMatrix = new int[6, 6];
            IntMatrixList = new(200);

            MixedDataRender();
            PuzzleOne();
            PuzzleTwo();
        }

        private void PuzzleOne()
        {
            PrintCurrentMethod();
            Result1 = 0;
            Result2 = 0;
            bool end = false;
            List<int[,]> winOrder = new();
            foreach (var number in IntList)
            {
                foreach (var m in IntMatrixList)
                {
                    end = false;
                    if (m[0,0] == 0)
                    {
                        for (int row = 1, col = 1; row < m.GetLength(1); row++, col = 1)
                        {
                            for (; col < m.GetLength(0); col++)
                            {
                                if (m[row, col] == number)
                                {
                                    m[row, 0]++;
                                    m[0, col]++;
                                    m[row, col] = -1;
                                }
                                if (CheckBoard(m, row, col))
                                {
                                    m[0, 0] = number;
                                    winOrder.Add(m);
                                    end = true;
                                }
                                if (end)
                                    break;
                            }
                            if (end)
                                break;
                        }
                    }
                }
            }
            Result1 = SumBoard(winOrder[0]);
            Result2 = SumBoard(winOrder[^1]);
            PrintResults(Result1);
        }

        private void PuzzleTwo()
        {
            PrintCurrentMethod();
            PrintResults(Result2);
        }

        private bool CheckBoard(int[,] matrix, int row, int col)
        {
            return matrix[row, 0] == 5 || matrix[0, col] == 5;
        }

        private int SumBoard(int[,] m)
        {
            int number = m[0, 0];
            int sum = 0;
            for(int row = 1, col = 1; row < m.GetLength(1); row++, col = 1)
            {
                for(; col < m.GetLength(0); col++)
                {
                    if (m[row, col] > -1)
                        sum += m[row, col];
                }
            }
            return sum * number;
        }

        private void MixedDataRender()
        {
            var result = File.ReadAllLines(Input.GetFullFileName());

            for (int i = 0; i < result.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(result[i]))
                    continue;
                if (result[i].Contains(','))
                {
                    IntList = result[0].Split(',').Select(int.Parse).ToList();
                }
                else
                {
                    if (result[i][0] == ' ')
                        result[i] = result[i].Substring(1).Replace("  ", " ");
                    else
                        result[i] = result[i].Replace("  ", " ");
                    int[] list = result[i].Split(" ").Select(int.Parse).ToArray();
                    for (int row = 1, col = 1; row < IntMatrix.GetLength(1); row++)
                    {
                        if (IntMatrix[row, 1] == 0 && IntMatrix[row, 2] == 0)
                        {
                            foreach (var x in list)
                            {
                                IntMatrix[row, col] = x;
                                col++;
                            }
                            row = IntMatrix.GetLength(1);
                        }
                    }
                    if (IntMatrix[5, 4] > 0 || IntMatrix[5, 5] > 0)
                    {
                        IntMatrixList.Add(IntMatrix);
                        IntMatrix = new int[6, 6];
                    }
                }
            }
        }
    }
}
