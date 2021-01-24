    public static List<int[]> Parse(List<string> list)
    {
        var result = new List<int[]>();
        foreach(var str in list)
        {
            try 
            {
                result.AddRange(str => str.Split(';'))
                        .Select(str => Tuple.Create(
                            int.Parse(str[0]), 
                            int.Parse(str[1]), 
                            int.Parse(str[2]))
                        );
            }
            catch
            {
                //here in braces I want to know, which element was wrong
                throw new FormatException($"Wrong line " + str");
            }
        }
        return result;
    }
