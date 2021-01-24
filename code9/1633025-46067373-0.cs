    FieldInfo[] fields = typeof(SystemResults).GetFields(
                             BindingFlags.NonPublic |
                             BindingFlags.Instance).ToArray(); // gets xyz and the other private fields
    
    List<int> testResults = new List<int>() { 1,23,4,5,6,7}; // list of integer to set
    
    SystemResults sysres = new SystemResults(); // instance of object
    fields[0].SetValue(sysres, testResults); // I know that fields[0] is xyz (you need to find it first), 
    // sets list of int to object
