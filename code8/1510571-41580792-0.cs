    string line;
    var str=new List<string>();
    // Read the file and display it line by line.
    System.IO.StreamReader file = new System.IO.StreamReader("c:\\test.txt");
    while((line = file.ReadLine()) != null)
    {
       str.Add(line);
    }
    
    file.Close();
    
    return string.Join(",",str);
