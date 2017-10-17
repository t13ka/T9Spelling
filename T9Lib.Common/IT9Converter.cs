namespace T9Common
{
    public interface IT9Converter
    {
        string[] ConvertLines(string[] lines);

        string ConvertString(string input);
    }
}