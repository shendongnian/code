    string s2 = "13.3";
    int i;
    //i = Convert.ToInt32(s2);                   // Run Time Error
    Console.WriteLine(int.TryParse(s2, out i));  // False
    Console.WriteLine(i);                        // Output will be 0
    string s3 = "Hello";
    //i = Convert.ToInt32(s2);                  // Run Time Error
    Console.WriteLine(int.TryParse(s3, out i)); // False
    Console.WriteLine(i);                       // Output will be 0
    string s1 = null;
    Console.WriteLine(int.TryParse(s1, out i));  // False
    Console.WriteLine(i);                        // Output will be 0
    string s4 = "0";      
    Console.WriteLine(int.TryParse(s4, out i));  // return True
    Console.WriteLine(i);                        // Output will be 0
