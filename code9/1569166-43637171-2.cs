    public static List<int[]> Parse(List<string> list)
    {
        var result = new List<int[]>();
        foreach(var str in list)
        {
            try 
            {
                var values = str.Split(';');
                result.Add(Tuple.Create(
                            int.Parse(values[0]), 
                            int.Parse(values[1]), 
                            int.Parse(values[2]))
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
