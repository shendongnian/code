    //you ever need a class wide variable to hold your dictionary, or you need to make a new one in the Main method 
    static Dictionary<string, string> myDict = new Dictionary<string, string>();
    public static void Main(string[] args)
    {
        DictionaryTest(myDict, "this","that"); //you didn't pass a dictionary object when you called this method
    }
    public static void DictionaryTest(Dictionary<string, string> testDictionary, string keyToAdd, string valToAdd) //you didn't have parameters for the strings you passed when you called this method
    {
      testDictionary[keyToAdd] = valToAdd; //same as Add(), but doesn't crash on dupe
      //I generally iterate dictionaries by iterating the keys collection and accessing the dictionary whenever I need to, rather than accessing a collection of keyvaluepair
      foreach (string key in testDictionary.Keys)
      {
        Console.WriteLine(key);
        Console.WriteLine(testDictionary[key]);
      }
    }
