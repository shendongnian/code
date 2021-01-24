        bool hasError = false;
        List<string> lines = new List<string>();
        using (StreamReader sr = file.OpenText())
        {
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                if (s.Contains("ORDERR"))
                {
                    hasError = true;
                    break;
                 } else {
                    lines.Add(s)
                 }
            }
        }
        if (!hasError) 
        {
            // do something with lines as we were ok with it 
        }
    }
