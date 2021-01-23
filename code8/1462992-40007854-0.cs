    using System;
    using System.Globalization;
    using System.Text;
    					
    public class Program
    {
    	public static void Main(string[] args)
        {
            string text = "a\u2705b\U0001f52ec\u26f1d\U0001F602e\U00010000";
            string cleansed = RemoveOtherSymbols(text);
            Console.WriteLine(cleansed);
        }
        
        static string RemoveOtherSymbols(string text)
        {
            // TODO: Handle malformed strings (e.g. those
            // with mismatched surrogate pairs)
            StringBuilder builder = new StringBuilder();
            int index = 0;
            while (index < text.Length)
            {
                // Full Unicode character
                int units = char.IsSurrogate(text, index) ? 2 : 1;
                UnicodeCategory category = char.GetUnicodeCategory(text, index);
                int ch = char.ConvertToUtf32(text, index);
                if (category == UnicodeCategory.OtherSymbol)
                {
                    Console.WriteLine($"Skipping U+{ch:x} {category}");
                }
                else
                {
                    Console.WriteLine($"Keeping U+{ch:x} {category}");
                    builder.Append(text, index, units);
                }
                index += units;
            }
            return builder.ToString();
        }
    }
