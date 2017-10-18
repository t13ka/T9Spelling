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
            Console.WriteLine(
                "Please, input the full filename(with path) of your file and press 'enter'. For example: \"c:\\C-small-practice.in\"");
            Console.Write("Or enter 'exit' to quit.");
            Console.WriteLine(Environment.NewLine);

            string input;

            do
            {
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Error! Please enter valid filename");
                    continue;
                }

                if (input.ToLower().Trim() == "exit")
                {
                    return;
                }
            }
            while (string.IsNullOrEmpty(input));

            var outputFilePath = Handling(new FileInfo(input));

            Console.WriteLine("Done!");
            Console.WriteLine("Your output file is:" + outputFilePath);
            Console.ReadKey();
        }

        public static string[] ConvertToOutputLInes(string[] inputLines)
        {
            return inputLines.Select((inputLine, index) => $"Case #{index + 1}: {inputLine}").ToArray();
        }

        private static string Handling(FileInfo fileInfo)
        {
            var converter = new T9Converter();
            var fileProvider = new FileProvider();
            var inputLines = fileProvider.ReadFileLines(fileInfo);
            var outputLines = converter.ConvertLines(inputLines);
            var formatedLines = ConvertToOutputLInes(outputLines);

            var path = fileInfo.DirectoryName;
            var outputFileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileInfo.FullName);
            var fullPath = Path.Combine(path, outputFileNameWithoutExtension + ".out");
            fileProvider.WriteOutputFile(fullPath, formatedLines);

            return fullPath;
        }
    }
}