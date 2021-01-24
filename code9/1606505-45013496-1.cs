       char[] delims = {','};  // the split delimiter
       string trimmedField = ""; // holds a single trimmed field
       string[] allLines = File.ReadAllLines(path);
        using (StreamWriter sw = new StreamWriter(path))
        {
            foreach (string line in allLines)
            {
                if (!string.IsNullOrEmpty(line) && line.Length > 1)
                {
                    string[] fields = line.Trim().Split(delims); // split it
                    foreach(string f in fields)
                    {
                        trimmedField = f.Trim(); // trim this field
                        //... do your thing here...
                    }
      
