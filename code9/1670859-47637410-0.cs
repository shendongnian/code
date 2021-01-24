    using System;
    using System.Text.RegularExpressions;
     
    public class Example
    {
        public static void Main()
        {
            string pattern = @"(?:(?:^|(?<=@))([^.@])|\G(?!\A))[^.@](?:([^.@])(?=[.@]))?";
            string substitution = @"$1*$2";
            string input = @"userone@domain.com
    usertwo@domain.com.co";
            RegexOptions options = RegexOptions.Multiline;
     
            Regex regex = new Regex(pattern, options);
            Console.WriteLine(regex.Replace(input, substitution));
        }
    }
