    static void Main(string[] args)
    {
        var s = ",something2,something3,,something5,something1,,something3,something4,";
        var splittedArray = s.Split(',');
        for (int i = 0; i < splittedArray.Length; i++)
        {
            if (splittedArray[i] == string.Empty)
            {
                splittedArray[i] = "None";
            }
        }
    }
