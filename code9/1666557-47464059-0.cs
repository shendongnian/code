    // create a new A object in memory and a variable called var1 that points to it
    A var1 = new A() { name = "" };
    
    // get the list of properties on the A class
    PropertyInfo[] info = var1.GetType().GetProperties();
    // create a variable called obj1 that points to the value of 
    // the first property on the A object created above (I.e. the empty string ""),
    object obj1 = info[0].GetValue(var1);
    // create a new A object in memory and a variable called var2 that points to it
    A var2 = new A() { name = "newname" };
    // change the variable obj1 to point to the new A object 
    // instead of the string it previously pointed to
    obj1 = (object)var2;
    // print the name property of the first A, which has not changed since creation
    Console.WriteLine(var1.name);
