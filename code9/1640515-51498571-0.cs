     public static string RemoveSpaces(this String Value)
        {
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex(@"[ ]{2,}", options);
            return regex.Replace(Value.Trim(), @" ");
        }
