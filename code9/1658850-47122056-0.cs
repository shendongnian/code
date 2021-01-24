    public static RecordClass[] Init(int Size)
    {
        //RNG for phone numbers
        Random Rnd = new Random();
        //Creating an array of RecordClass
        RecordClass[] rArray = new RecordClass[Size];
        //Loop through the array
        for(int i = 0; i < rArray.Length; i++)
        {
            rArray[i].Name = "Name" + i;
            rArray[i].Number = Rnd.Next();
            rArray[i].Email = rArray[i].Name + "@gmail.com";
        }
        return rArray;
    }
    static void Main(string[] args)
    {
        //Initialize array based on number of records
        //Calling FindByName
        RecordArray.FindByName (RecordArray.Init(5), "Name3");
    }
