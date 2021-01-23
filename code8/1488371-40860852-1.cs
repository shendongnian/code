        string Format(string str, string separator)
        {
           var delimiter = char.Parse(separator);
            var cArray = str.Select(c => !char.IsLetterOrDigit(c) ? delimiter : c ).ToArray();
            return new string(cArray);
        }
