        string str = "111(222(333(444()))555(666(77(8888)))()";
        var eliminateBracket = ReplaceBrackets(str);
        static string ReplaceBrackets(string input) {
            string regex = @"\([^()]*\)";
            string result = input;
            string previous = input;
            while (previous.Length !=
                (result = Regex.Replace(result, regex, "")).Length
                ) {
                previous = result;
            }
            return result;
        }
