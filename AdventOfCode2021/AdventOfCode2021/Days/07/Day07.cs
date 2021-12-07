using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Days
{ 
    class Day07 : BaseDay
    {
        List<int> Crabs { get; set; }

        public Day07(string day, bool hasInput) : base(day, hasInput)
        {
            PrintCurrentClass();

            Crabs = FileInput.FirstOrDefault().Split(",").Select(int.Parse).OrderBy(n => n).ToList();
            var sortedNumbers = Crabs;
            int numberCount = Crabs.Count();
            int halfIndex = Crabs.Count() / 2;
            double mean = Crabs.Average();
            double median;
            if ((numberCount % 2) == 0)
            {
                median = ((sortedNumbers.ElementAt(halfIndex) +
                    sortedNumbers.ElementAt((halfIndex - 1))) / 2);
            }
            else
            {
                median = sortedNumbers.ElementAt(halfIndex);
            }
            int crabPosition1 = (int)Math.Truncate(median);
            int crabPosition2 = (int)Math.Truncate(mean);
            foreach (int crab in Crabs)
            {
                Result1 += Math.Abs(crab - crabPosition1);
                Result2 += CalculateCrabFuel(crab, crabPosition2);
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

        private int CalculateCrabFuel(int crab, int crabPosition2)
        {
            int fuelUsed = 0;
            int diff = Math.Abs(crab - crabPosition2);
            for (int i = 1; i <= diff; i++)
            {
                fuelUsed += i;
            }
            return fuelUsed;
        }
    }
}
