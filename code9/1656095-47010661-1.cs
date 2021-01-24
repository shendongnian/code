    IEnumerable<MyClass> ConvertTxtFile(string fileName)
    {
        // TODO: checks to see if fileName is proper file
        IEnumerable<string> lines = System.IO.File.ReadAllLines(fileName);
        foreach(string line in lines)
        {
           yield return StringToMyClass(line);
        }
    }
    MyClass StringToMyClass(string line)
    {
        // TODO: code to convert your line into a MyClass.
    }
