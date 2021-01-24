    string line;
    int sum = 0;
    // Read the file and display it line by line.
    System.IO.StreamReader file = 
       new System.IO.StreamReader("c:\\test.txt");
    while((line = file.ReadLine()) != null)
    {
       string[] arr = line.split("|"); // split the line into an array
       sum += Int32.Parse(arr[2]); // get the 3rd element in the row an convert it to int
    }
    
    file.Close();
