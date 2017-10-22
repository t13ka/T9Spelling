namespace T9Lib
{
    using System.IO;

    using T9Common;

    public class FileProvider : IFileProvider
    {
        private readonly IT9Converter _converter;

        public FileProvider(IT9Converter converter)
        {
            _converter = converter;
        }

        public FileInfo FileHandling(FileInfo fileInfo)
        {
            var rowIndex = 0;
            var outFile = Path.ChangeExtension(fileInfo.FullName, ".out");
            using (var streamReader = new StreamReader(fileInfo.Name))
            {
                using (var streamWriter = new StreamWriter(outFile))
                {
                    do
                    {
                        var row = streamReader.ReadLine();
                        if (rowIndex == 0)
                        {
                            rowIndex++;
                            continue;
                        }

                        var convertedRow = _converter.ConvertString(row);

                        var outputRow = $"Case #{rowIndex}: {convertedRow}";

                        streamWriter.WriteLine(outputRow);
                        rowIndex++;
                    }
                    while (streamReader.EndOfStream == false);
                }
            }

            return new FileInfo(outFile);
        }
    }
}