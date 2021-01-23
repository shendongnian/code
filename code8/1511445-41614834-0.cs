    static void Main(string[] args)
    {
        List<SomeObject> myCollection = new List<SomeObject>()
        {
            new SomeObject() { Amount = 3 },
            new SomeObject() { Amount = 6 },
            new SomeObject() { Amount = 9 }
        };
    
        int totalAccumulated = 0;
    
        for (int i = 0; i < myCollection.Count; i++)
        {
            PopulateAndCalculate(myCollection[i], ref totalAccumulated);
        }
    
         /*****This is the new part*******/
        myCollection[0].TotalAmount = totalAccumulated;
        myCollection[1].TotalAmount = totalAccumulated;
        myCollection[2].TotalAmount = totalAccumulated;
    
        Console.WriteLine($"The total accumulated is: {totalAccumulated}");
    }
    private static void PopulateAndCalculate(SomeObject prmObject, ref int accumulatedTotal)
    {
        //Populate a lot of another fields
        accumulatedTotal += prmObject.Amount;
       //no need to mess with the total here as far as the properties are concerned.
      
    }
