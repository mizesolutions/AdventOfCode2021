﻿using System;
using AdventOfCode2021.Days;

namespace AdventOfCode2021
{
    class Program
    {
        static int Main(string[] args)
        {
            bool isInput = true;
            var day = "";

            if (args != null && args.Length > 0)
            {
                if (args.Length == 2 && args[0].Contains("-n"))
                {
                    isInput = false;
                    day = args[1];
                }
                else
                {
                    day = args[0];
                }
                return RunDay(day, isInput);
            }
            else
            {
                Console.WriteLine($"No args found - \r\nUsage: \r\n\taoc21 day##   normal operation\r\n\taoc21 -n day##   to run with no input");
                return 0;
            }

            static int RunDay(string day, bool flag)
            {
                switch (day)
                {
                    case "day01":
                        _ = new Day01(day, flag);
                        break;
                    case "day02":
                        _ = new Day02(day, flag);
                        break;
                    case "day03":
                        _ = new Day03(day, flag);
                        break;
                    case "all":
                        _ = new Day01("day01", flag);
                        _ = new Day02("day02", flag);
                        _ = new Day03("day03", flag);
                        break;
                    default:
                        return 0;
                }
                return 1;
            }
        }
    }
}
