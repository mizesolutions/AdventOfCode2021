using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Days
{
    class Day06 : BaseDay
    {
        private List<int> FishCount { get; set; }
        private long[] FishState { get; set; }
        private long FishResult1 { get; set; }
        private long FishResult2 { get; set; }

        public Day06(string day, bool hasInput) : base(day, hasInput)
        {
            PrintCurrentClass();
            FishCount = FileInput.FirstOrDefault().Split(",").Select(int.Parse).ToList();
            FishState = new long[9];

            PuzzleOne();
            PuzzleTwo();
        }

        private void PuzzleOne()
        {
            PrintCurrentMethod();
            foreach (var fish in FishCount)
            {
                FishState[fish] += 1;
            }

            long resetFish = 0;
            for (int day = 1; day <= 256; day++)
            {
                FishState[0] = FishState[1];
                FishState[1] = FishState[2];
                FishState[2] = FishState[3];
                FishState[3] = FishState[4];
                FishState[4] = FishState[5];
                FishState[5] = FishState[6];
                FishState[6] = FishState[7];
                FishState[7] = FishState[8];
                FishState[6] += resetFish;
                FishState[8] = resetFish;
                resetFish = FishState[0];
                if (day == 80)
                {
                    FishResult1 = FishState.Sum();
                }
            }
            FishResult2 = FishState.Sum();

            PrintResults(FishResult1);
        }

        private void PuzzleTwo()
        {
            PrintCurrentMethod();

            PrintResults(FishResult2);
        }
    }
}
