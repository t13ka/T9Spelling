namespace T9Lib.Demo
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net.Mime;

    using T9Lib;

    class Program
    {
        static void Main(string[] args)
        {
            Handling("C-small-practice");
            Handling("C-large-practice");

            Console.WriteLine("Done!");
            Console.WriteLine("Please, check path:" + System.Environment.CurrentDirectory);
            Console.ReadKey();
        }

        public static string[] ConvertToOutputLInes(string[] inputLines)
        {
            return inputLines.Select((inputLine, index) => $"Case #{index + 1}: {inputLine}").ToArray();
        }

        private static void Handling(string fileName)
        {
            var converter = new T9Converter();
            var fileProvider = new FileProvider();
            var inputLines = fileProvider.ReadFileLines(new FileInfo(fileName + ".in"));
            var outputLines = converter.ConvertLines(inputLines);
            var formatedLines = ConvertToOutputLInes(outputLines);
            fileProvider.WriteOutputFile(fileName + ".out", formatedLines);
        }
    }
}