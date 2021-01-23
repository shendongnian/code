    string[] original = System.IO.File.ReadAllLines("path/to/file");
    List<string> working = new List<string>;
    
    int i = 0;
    while (i < original.Length)
    {
        if (i % 2 != 0)
        {
            // line is odd - check whether this is a duplicate
            int dupeCount = working.Where(a => a == original[i]).ToList().Count;
            if (dupeCount > 0)
            {
                // this is a duplicate - skip this AND the next line
                i += 2;
                continue;
            }
            else
            {
                // no duplicate found - add to list
                working.Add(original[i]);
            }
        }
        else
        {
            // line is even - value always gets added
            working.Add(original[i]);
        }  
        i++;      
    }
    // List<string> working should now contain the output you want
