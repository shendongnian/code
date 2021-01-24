    public static List<List<string>> Split(this List<string> array, string seperator)
    {
        var currentIndex = 0;
        var splitedList = new List<List<string>>();
        while (currentIndex < array.Count)
        {
            var part = array.Skip(currentIndex).TakeWhile(item => item != seperator).ToList();
            splitedList.Add(part);
            currentIndex += part.Count + 1;
        }
        return splitedList;
    }
    string[] stringArray = new string[6];
    stringArray[0] = "Hi there, this is page one"; //goes into new arrayA
    stringArray[1] = "Hi there, this is page two"; //goes into new arrayA
    stringArray[2] = "Hi there, this is page three"; //goes into new arrayA
    stringArray[3] = "@"; //split
    stringArray[4] = "New book, page one"; //goes into new arrayB
    stringArray[5] = "New book, page two"; //goes into new arrayB
    var splittedValue = stringArray.ToList().Split("@");
