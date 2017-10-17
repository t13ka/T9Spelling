namespace T9Common
{
    using System.IO;

    public interface IFileProvider
    {
        string[] ReadFileLines(FileInfo fileInfo);

        void WriteOutputFile(string fileName, string[] lines);
    }
}