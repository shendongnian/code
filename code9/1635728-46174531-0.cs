    static List<string> ListOfPositive = new List<string>();
    static List<string> ListOfNegative = new List<string>();
    static bool InitialPositiveCheck = false;
    static void Main(string[] args)
    {
        string InputStr = "DIM H + QUT OF PIP DIM - DIM L + XYZ - ABC";
        AddToLIst(InputStr);
        ListOfPositive.Reverse();
        ListOfNegative.Reverse();
        Console.WriteLine(string.Join("", ListOfPositive));
        Console.WriteLine(string.Join("", ListOfNegative));         
    }
    static void AddToLIst(string newstring)
    {
        if (!(newstring.Trim().StartsWith("+")) && !InitialPositiveCheck)
        {
           newstring = "+ " + newstring;
           InitialPositiveCheck = true;
        }
        int indexOfPlus = newstring.LastIndexOf("+");
        int indexOfMinus = newstring.LastIndexOf("-");
        string str = "";
        if (indexOfMinus == -1 && indexOfPlus == -1)
            return;
        if (indexOfPlus < indexOfMinus)
        {
           str = newstring.Substring(indexOfMinus + 1);
           ListOfNegative.Add(str);
           str = newstring.Remove(indexOfMinus);
           AddToLIst(str);
        }
        else
        {
           str = newstring.Substring(indexOfPlus + 1);
           ListOfPositive.Add(str);
           str = newstring.Remove(indexOfPlus);
           AddToLIst(str);
        }
     }
