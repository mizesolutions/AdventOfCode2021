using AdventOfCode2021.Infrastructure.Services;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace AdventOfCode2021.Days._00
{
    public class BaseDay
    {
        public RenderInput Input { get; set; }
        public int Count { get; set; }

        public BaseDay(string day, bool hasInput)
        {
            if (hasInput)
            {
                try
                {
                    Input = new RenderInput(day);
                }
                catch (FileNotFoundException fe)
                {
                    Console.WriteLine(fe.Message);
                    Environment.Exit(0);
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetCurrentMethod()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            return $"  {sf.GetMethod().Name}";
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetCurrentClass()
        {
            return $"--==<  {this.GetType().Name}  >==--";
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetResults()
        {
            return $"      Result: {Count}\r\n";
        }
    }
}
