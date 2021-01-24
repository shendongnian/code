    public static Dictionary<string, MyObject> MyOtherDictionary;
    // ...
    static Constants
    {
        MyOtherDictionary = new Dictionary<string, MyObject>(MyDictionary);
        MyOtherDictionary.Remove("second");
        MyOtherDictionary.Add("Third", new MyObject());
    }
