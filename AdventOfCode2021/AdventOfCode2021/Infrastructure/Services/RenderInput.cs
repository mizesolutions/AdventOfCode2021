using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.Infrastructure.Services
{
    public class RenderInput
    {
        public string InputName { get; set; }
        public List<string> Output { get; set; }

        private const string __path = @"C:\source\repos\AdventOfCode2021\AdventOfCode2021\AdventOfCode2021\Infrastructure\Input\";

        public RenderInput(string inputName)
        {
            if(File.Exists(__path+inputName+".txt"))
            {
                this.InputName = inputName + ".txt";
                this.Output = ReadFile();
            }
            else
            {
                throw new FileNotFoundException($"Error: {inputName}.txt not found in {__path}\r\n");
            }
        }

        public List<string> ReadFile()
        {
            List<string> output = new ();

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
    }
}
