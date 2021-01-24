    void method1(){ method2(); }
    void method2(){ method3(); }
    void method3()
    {
        string[] fileEntries = Directory.GetFiles(filepath, "*.csv");.
    
        if (fileEntries.Length == 0)
        {
             throw new Exception("No *.csv files available");
        }
    }
