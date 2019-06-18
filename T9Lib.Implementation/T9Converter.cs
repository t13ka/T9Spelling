namespace T9Lib
{
    using System.Collections.Generic;
    using System.Text;

    using T9Common;

    /// <summary>
    /// The t9 converter.
    /// </summary>
    public class T9Converter : IT9Converter
    {
        private static Dictionary<char, string> T9Map;

        public T9Converter()
        {
            T9Map = new Dictionary<char, string>
                        {
                            { ' ', "0,1" },
                            { 'a', "2,2" },
                            { 'b', "22,2" },
                            { 'c', "222,2" },
                            { 'd', "3,3" },
                            { 'e', "33,3" },
                            { 'f', "333,3" },
                            { 'g', "4,4" },
                            { 'h', "44,4" },
                            { 'i', "444,4" },
                            { 'j', "5,5" },
                            { 'k', "55,5" },
                            { 'l', "555,5" },
                            { 'm', "6,6" },
                            { 'n', "66,6" },
                            { 'o', "666,6" },
                            { 'p', "7,7" },
                            { 'q', "77,7" },
                            { 'r', "777,7" },
                            { 's', "7777,7" },
                            { 't', "8,8" },
                            { 'u', "88,8" },
                            { 'v', "888,8" },
                            { 'w', "9,9" },
                            { 'x', "99,9" },
                            { 'y', "999,9" },
                            { 'z', "9999,9" }
                        };
        }

        public string ConvertString(string input)
        {
            var sb = new StringBuilder();
            var charArray = input.ToCharArray();
            var lastButton = string.Empty;
            foreach (var currentChar in charArray)
            {
                if (T9Map.TryGetValue(currentChar, out var map))
                {
                    var strings = map.Split(',');
                    var value = strings[0];
                    var group = strings[1];
                    if (lastButton == group)
                    {
                        sb.Append(" ");
                    }

                    lastButton = group;
                    sb.Append(value);
                }
                else
                {
                    // idle
                }
            }

            return sb.ToString();
        }
    }
}