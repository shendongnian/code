    using System;
    using System.Text.RegularExpressions;
    ..........
    ...........
        public void removeHash(String input)
        {
            string pattern = @"^\s*#.*$";
            string substitution = @"";
    
            RegexOptions options = RegexOptions.Multiline;
            
            Regex regex = new Regex(pattern, options);
            string result = regex.Replace(input, substitution);
            return result;
        }
