    // create a placeholder for processed lines
    List<List<string>> _output = new List<List<string>>();
    
    using (StreamReader reader = new StreamReader(File.OpenRead(filePath)))
    {
        int i = 0; // create indexer
        _output.Add(new List<string>()); // add new sequence
        _output.Last().Add(i.ToString() + "."); // insert sequence indexer
        string line = string.Empty;
        while( (line = reader.ReadLine()) != null)
        {
            if(string.IsNullOrWhiteSpace(line))
            {
                i++;
                _output.Add(newList<string>());
                _output.Last().Add(i.ToString() + ".");
            }
            else
            {
                _output.Last().Add(line);
            }
        }
    }
