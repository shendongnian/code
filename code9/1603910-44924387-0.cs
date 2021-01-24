    var test = "this.is.a.test........";
    Console.WriteLine(test.CountTrailingDots());
    public static int CountTrailingDots(this string value)
    {
        return value.Length - value.TrimEnd('.').Length;
    }
