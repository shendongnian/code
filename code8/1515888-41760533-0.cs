    public static string CheckSpecialCharacter(string value)
        {
           System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"[~`!@#$%^*()=|\{}';.,<>]");
           if (regex.IsMatch(value))
           {
              return regex.Match(value).Value;
           }
           else
           {
              return string.empty;
           }
        }
