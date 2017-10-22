namespace T9Common
{
    using System.IO;

    public interface IFileProvider
    {
        FileInfo FileHandling(FileInfo fileInfo);
    }
}