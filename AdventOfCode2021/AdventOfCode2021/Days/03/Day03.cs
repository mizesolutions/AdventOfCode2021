using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Days
{
    class Day03 : BaseDay
    {
        private int[] MCcount { get; set; }
        private int[] LCcount { get; set; }

        public Day03(string day, bool hasInput) : base(day, hasInput)
        {
            PrintCurrentClass();
            PuzzleOne();
            PuzzleTwo();
        }

        private void PuzzleOne()
        {
            PrintCurrentMethod();

            ComputeCommons(Input.Output);

            var gamma = Convert.ToInt32(string.Join("", MCcount), 2);
            var epsilon = Convert.ToInt32(string.Join("", LCcount), 2);

            Result = gamma * epsilon;
            PrintResults();
        }

        private void PuzzleTwo()
        {
            PrintCurrentMethod();
            Result = 0;
            List<string> o2 = FilterList(Input.Output, MCcount, 0, true);
            ComputeCommons(Input.Output);
            List<string> co2 = FilterList(Input.Output, LCcount, 0, false);

            var o2Int = Convert.ToInt32(o2.FirstOrDefault().ToString(), 2);
            var co2Int = Convert.ToInt32(co2.FirstOrDefault().ToString(), 2);

            Result = o2Int * co2Int;
            PrintResults();
        }

        private void ComputeCommons(List<string> list)
        {
            MCcount = new int[Input.Output[0].Length];
            LCcount = new int[Input.Output[0].Length];

            foreach (var s in list)
            {
                for (var i = 0; i < s.Length; i++)
                {
                    if (s[i].Equals('1'))
                        MCcount[i]++;
                }
            }

            for (var i = 0; i < MCcount.Length; i++)
            {
                if (list.Count - MCcount[i] <= MCcount[i])
                {
                    MCcount[i] = 1;
                    LCcount[i] = 0;
                }
                else
                {
                    MCcount[i] = 0;
                    LCcount[i] = 1;
                }
            }
        }

        private List<string> FilterList(List<string> list, int[] filterByArray, int index, bool mostCommon)
        {
            if (list.Count == 1 || index == Input.Output[0].Length)
                return list;

            var filteredList = list.Where(x => x.Substring(index).StartsWith(filterByArray[index].ToString())).ToList();
            ComputeCommons(filteredList);
            filterByArray = mostCommon ? MCcount : LCcount;
            index++;
            return FilterList(filteredList, filterByArray, index, mostCommon);
        }
    }
}
