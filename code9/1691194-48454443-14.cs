    public static int GetValueBeforeDot(string input){
           return int.Parse(input.Substring(0, input.IndexOf('.'))
                       .Where(char.IsDigit)
                            .Aggregate(string.Empty, (e, a) => e + a));
    }
