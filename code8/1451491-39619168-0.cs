    public static string ModifyPositions(string positionsInput, int displacement)
        {
            string input = "l=50; r=190; t=-430; b=-480";
            var pattern = @"(t|b)=(-?\d+)";
            var regex = new Regex(pattern);
            var matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                input = input.Replace(match.Groups[2].Value, (int.Parse(match.Groups[2].Value) + displacement).ToString());
            }
            return input;
        }
