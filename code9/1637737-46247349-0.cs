            // using System.Text.RegularExpressions;
            string TheSearchString = "John";
            string ContactFirst = "Johnson";
            // any number of whitespaces around the searched-pattern permitted but no other characters
            string pattern1 = @"^[ \t\r\n]*\b" + TheSearchString + @"\b[ \t\r\n]*$";
            // exactly the searched-pattern with no surrounding whitespace permitted (same as equals)
            string pattern2 = @"^\b" + TheSearchString + @"\b$";
            // the searched-pattern as a stand-alone word anywhere 
            string pattern3 = @"\b" + TheSearchString + @"\b";
            Regex r = new Regex(pattern3, RegexOptions.IgnoreCase);
            bool result = r.IsMatch(ContactFirst);
            int foundAt = -1;
            // the string index of the first match from the Matches collection
            if (result)
                foundAt = r.Matches(ContactFirst)[0].Index;
