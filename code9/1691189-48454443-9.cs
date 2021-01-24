    public static string GetValueBeforeDot(string input){
         return input.Substring(0, input.IndexOf('.'))
                     .Where(char.IsDigit)
                     .Aggregate(string.Empty, (e, a) => e + a);
    }
