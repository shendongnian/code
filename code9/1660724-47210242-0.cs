            string input = "ABC|DEF|XYZ|TT1234";
            Regex regex = new Regex(@"([^|]+$)");
            Match match = regex.Match(input);
            if (match.Success)
            {
                //replace
                string output = Regex.Replace(match.Value, "TT", "YY");
                Console.WriteLine(output);
            }
            Console.Read();
