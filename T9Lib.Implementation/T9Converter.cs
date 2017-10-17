namespace T9Lib
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    using T9Common;

    /// <summary>
    ///     The T9 utils.
    /// </summary>
    public class T9Converter : IT9Converter
    {
        private readonly Tuple<char, short, short>[] T9Map;

        public T9Converter()
        {
            T9Map = new[]
                        {
                            new Tuple<char, short, short>(' ', 0, 1), new Tuple<char, short, short>('a', 2, 2),
                            new Tuple<char, short, short>('b', 22, 2), new Tuple<char, short, short>('c', 222, 2),
                            new Tuple<char, short, short>('d', 3, 3), new Tuple<char, short, short>('e', 33, 3),
                            new Tuple<char, short, short>('f', 333, 3), new Tuple<char, short, short>('g', 4, 4),
                            new Tuple<char, short, short>('h', 44, 4), new Tuple<char, short, short>('i', 444, 4),
                            new Tuple<char, short, short>('j', 5, 5), new Tuple<char, short, short>('k', 55, 5),
                            new Tuple<char, short, short>('l', 555, 5), new Tuple<char, short, short>('m', 6, 6),
                            new Tuple<char, short, short>('n', 66, 6), new Tuple<char, short, short>('o', 666, 6),
                            new Tuple<char, short, short>('p', 7, 7), new Tuple<char, short, short>('q', 77, 7),
                            new Tuple<char, short, short>('r', 777, 7), new Tuple<char, short, short>('s', 7777, 7),
                            new Tuple<char, short, short>('t', 8, 8), new Tuple<char, short, short>('u', 88, 8),
                            new Tuple<char, short, short>('v', 888, 8), new Tuple<char, short, short>('w', 9, 9),
                            new Tuple<char, short, short>('x', 99, 9), new Tuple<char, short, short>('y', 999, 9),
                            new Tuple<char, short, short>('z', 9999, 9)
                        };
        }

        public string[] ConvertLines(string[] lines)
        {
            var list = new List<string>();
            if (lines == null)
            {
                throw new NullReferenceException("lines can't be equal null");
            }

            foreach (var line in lines)
            {
                try
                {
                    var converted = ConvertString(line);
                    list.Add(converted);
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return list.ToArray();
        }

        public string ConvertString(string input)
        {
            var stringBuilder = new StringBuilder();
            var charArray = input.ToCharArray();
            var lastButton = 0;
            foreach (var currentChar in charArray)
            {
                var firstOrDefault = T9Map.FirstOrDefault(t => t.Item1 == currentChar);
                if (firstOrDefault != null)
                {
                    if (lastButton == firstOrDefault.Item3)
                    {
                        stringBuilder.Append(" ");
                    }

                    lastButton = firstOrDefault.Item3;

                    stringBuilder.Append(firstOrDefault.Item2);
                }
                else
                {
                    throw new ArgumentException("unknown character");
                }
            }

            return stringBuilder.ToString();
        }
    }
}