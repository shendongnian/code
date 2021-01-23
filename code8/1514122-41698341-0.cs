     string value = "HellO1234";
            IEnumerable<char> letters = value.Where(ch => char.IsLetter(ch));
            string letersString;
            string smallLetters;
            if(letters.Any())
            {
                letersString = new string( letters.ToArray());
                smallLetters = letersString.ToLower();
            }
