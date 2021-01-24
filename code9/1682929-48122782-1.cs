    void ParseLogin(string html,  out string  csrf)
    {
        csrf = null;
        // read each line of the html
        using(var sr = new StringReader(html))
        {
            string line;
            while((line = sr.ReadLine()) != null)   
            {
                // parse for csrf by looking for the input tag      
                if (line.StartsWith(@"<input type=""hidden"" name=""_csrf""") && csrf == null) 
                {
                    // string split by space
                    csrf = line
                        .Split(' ')  // split to array of strings
                        .Where(s => s.StartsWith("value"))  // value="what we need is here">
                        .Select(s => s.Substring(7,s.Length -9)) // remove value=" and the last ">
                        .First();
                }
            }
        }
    }
