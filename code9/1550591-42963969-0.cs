    static int counter = 0;
    static void getCounterValue(out int val)
    {
        val = counter;
        counter++;
    }
    static Nullable<int> getValidCounterValue()
    {
        int outResult;
        getCounterValue(out outResult);
        if (outResult < 10)
        {
            return null;
        }
        else
        {
            return outResult;
        }
    }
    static void Main()
    {
        Nullable<int> checkVal = new Nullable<int>();
            
        while (!checkVal.HasValue)
        {
            checkVal = getValidCounterValue();
            Console.WriteLine("Still waiting.");
        }
        Console.WriteLine("Done. Valid value is:" + checkVal.Value.ToString());
    }
