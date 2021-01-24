    using System;
    using System.Text.RegularExpressions;
    
    public class RegEx
    {
        public static void Main()
        {
            string pattern = @"<seg_(\d+)[\s\w]+=(\d+)>([\w\s]+)<\/seg_\d+>";
            string substitution = @"{""index"":""$1"",""status"":""$2"",""seg"":""$3""},";
            string input = @"<seg_0 status=0>This is segment zero</seg_0><seg_1 status=1>This is segment one</seg_1><seg_2 status=0>This is segment two</seg_2>";
            
            Regex regex = new Regex(pattern);
            string result = regex.Replace(input, substitution);
        }
    }
