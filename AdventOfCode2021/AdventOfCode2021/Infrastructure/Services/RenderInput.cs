using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.Infrastructure.Services
{
    public class RenderInput
    {
        public string InputName { get; set; }
        public List<int> IntList { get; set; }
        public int[,] IntMatrix { get; set; }
        public List<int[,]> IntMatrixList { get; set; }

        private const string __path = @"C:\source\repos\AdventOfCode2021\AdventOfCode2021\AdventOfCode2021\Infrastructure\Input\";

        public RenderInput(string inputName)
        {
            if (File.Exists(__path + inputName + ".txt"))
            {
                this.InputName = inputName + ".txt";
            }
            else
            {
                throw new FileNotFoundException($"Error: {inputName}.txt not found in {__path}\r\n");
            }
            IntList = new();
            IntMatrix = new int[6, 6];
            IntMatrixList = new(200);
        }

        public List<string> FileToList()
        {
            List<string> output = new();

            using (StreamReader file = new(__path + InputName))
            {
                var line = "";
                while ((line = file.ReadLine()) != null)
                {
                    output.Add(line);
                }
            }
            return output;
        }

        public void MixedDataRender()
        {
            var result = File.ReadAllLines(__path + InputName);

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
