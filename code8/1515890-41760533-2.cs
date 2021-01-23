    public static string CheckSpecialCharacter(string value)
        {
           System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"[~`!@#$%^*()=|\{}';.,<>]");
           var match = regex.Match(value);
           if (match.Success)
           {
              return match.Value;
           }
           else
           {
              return string.empty;
           }
        }
