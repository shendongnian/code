    List<string> lineData = new List<string>();
    foreach (string line in lines)
    {
        // Loop body code omitted...   
        lineData.Add(data);                        
    }
    // Now use WriteAllLines to write your new lines to the file
    File.WriteAllLines(@"C:\Users\Adnan Haider\Desktop\line.txt", lineData);
