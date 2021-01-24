    static void Main(string[] args)
    {
        var myString = "This is my string with some loooooooooooooong words. Please devide meeeeeeeeeeeeeeeeeeeeeeeee";
        var newString = string.Empty;
        var myStringSplit = myString.Split();
        var query = myStringSplit.Where(x => x.Length > 10).ToList();
        foreach (var item in myStringSplit)
        {
            if(item.Length > 10)
            {
                var itemToSplit = item;
                itemToSplit.Insert(5, " ");
                newString += itemToSplit;
            }
            else
            {
               newString += item;
            }
        }
    }
