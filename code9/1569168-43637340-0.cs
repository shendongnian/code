    public static List<int[]> Parse(List<string> list)
    {
        if (list == null)
        {
            throw new ArgumentNullException(nameof(list));
        }
        var arrayOfStringArray = list
            .Select(x => x.Split(';'))
            .ToArray();
        var resultList = new List<int[]>();
        for (var i = 0; i < arrayOfStringArray.Length; i++)
        {
            var arrayOfString = arrayOfStringArray[i];
            if (arrayOfString.Length != 3)
            {
                throw new InvalidOperationException("meaningfull message there!");
            }
            var arrayOfInt = new int[3];
            for (var j = 0; j < arrayOfInt.Length; j++)
            {
                arrayOfInt[j] = TryParse(arrayOfString[j], i, j);
            }
            resultList.Add(arrayOfInt);
        }
        return resultList;
    }
    static int TryParse(string value, int line, int position)
    {
        int result;
        if (!int.TryParse(value, out result))
        {
            throw new FormatException($"Item at position {line},{position} is invalid.");
        }
        return result;
    }
