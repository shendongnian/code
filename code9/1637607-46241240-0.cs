    // if IsPropertyValueAboveZero is intended to start above zero
    // then you can just initialize the counter to 1
    private static int globalID = 1;
    public void MyFunction(myClass thisClass, int id)
    {
        // ListOfMyClass and ListOfClasses are probably not thread-safe
        // and you may need to add locks around the Add and get a copy
        // of ListOfClasses before the foreach enumeration
        ListOfMyClass.Add(thisClass); 
        foreach (class someClass in ListOfClasses)
        {
            int newId = System.Threading.Interlocked.Increment(ref globalID);
            MyClass newClass = new MyClass(newId);
            MyFunction(newClass, newId);  //Recursive Call
        }
    }
