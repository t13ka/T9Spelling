namespace T9Lib.Demo
{
    using System;
    using System.IO;

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

            try
            {
                var fileProvider = new FileProvider(new T9Converter());
                var outputFilePath = fileProvider.FileHandling(new FileInfo(input));
                Console.WriteLine("Done! Your output file is:" + outputFilePath.FullName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}