    // Getting content of the file.
    string contents = File.ReadAllText(@"C:]test.txt");
    
    // Separating content           
    string[] contentArr  = contents.Split('\n');            
                
    List<string> characterList = new List<string>();
    List<int> valueList = new List<int>();
                
    foreach (string value in contentArr)
    {
    	characterList.Add(string.Join("", value.ToCharArray().Where(Char.IsLetter)).Trim());
    	valueList.Add(Int32.Parse(string.Join("", value.ToCharArray().Where(Char.IsDigit))));
    }
