    List<string> myStringList = new List<string>();
    List<double> myDoubleList = new List<double>();
    try {
        myStringList = (List<string>)myobject;
        for (int i = 0; i < myStringList.Count(); i++)
        {
            Console.WriteLine(myStringList[i]);
        }
    }
    catch (InvalidCastException)
    {
        myDoubleList = (List<double>)myobject;
        for (int i = 0; i < myDoubleList.Count(); i++)
        {
            Console.WriteLine(myDoubleList[i]);
        }
    }  
  
