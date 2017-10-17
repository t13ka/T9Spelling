using System;
using System.Linq;

namespace T9Lib
{
    using System.IO;

    using T9Common;

    public class FileProvider : IFileProvider
    {
        public string[] ReadFileLines(FileInfo fileInfo)
        {
            if (fileInfo == null)
            {
                throw new NullReferenceException("FileInfo not presented.");
            }

            var file = fileInfo.FullName;
            if (fileInfo.Exists == false)
            {
                throw new FileNotFoundException($"File \"{file}\" not found.");
            }

            string[] lines;
            try
            {
                var tempLines = File.ReadAllLines(file);
                if (tempLines.Any() == false)
                {
                    throw new ArgumentNullException($"File \"{file}\" has no data.");
                }

                if (int.TryParse(tempLines.First(), out int count))
                {
                    if (count == 0)
                    {
                        throw new ArgumentNullException($"Quantity of lines for File \"{file}\" can't be equal 0.");
                    }

                    lines = tempLines.Skip(1).Take(count).ToArray();

                    // todo: this case is optional
                    if (lines.Length < count)
                    {
                        throw new ArgumentNullException($"Quantity of lines for File \"{file}\" can't be more than specified quantity of lines.");
                    }
                }
                else
                {
                    throw new ArgumentNullException($"Parsing error for the first line of File \"{file}\".");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return lines;
        }

        public void WriteOutputFile(string fileName, string[] lines)
        {
            try
            {
                File.WriteAllLines(fileName, lines);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}