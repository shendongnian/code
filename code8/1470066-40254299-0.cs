        public static class Extension
    {
        public static List<string> sortItMyWay(this List<string> mylist)
        {
            string temp = string.Empty;
            for (int write = 0; write < mylist.Count; write++)
            {
                for (int sort = 0; sort < mylist.Count - 1; sort++)
                {
                    if (mylist[sort].Weight() > mylist[sort + 1].Weight())
                    {
                        temp = mylist[sort + 1];
                        mylist[sort + 1] = mylist[sort];
                        mylist[sort] = temp;
                    }
                }
            }
            return mylist;
        }
   
    public static int Weight (this string input)
    {
        var value = 0;
        for (int i = input.Length - 1; i >= 0 ; i--)
        {
            value += input[i] * (int)Math.Pow(10,i);
        }
        return value;
    }
 }
