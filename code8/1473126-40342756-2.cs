    private static int Decode(string value) {
      return value
        .Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries)
        .Select(item => int.Parse(item))
        .Aggregate((a, s) => s * 256 + a);
    } 
...
    // 4878
    Console.WriteLine(Decode("+ 14 + 19"));    
