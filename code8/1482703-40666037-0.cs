        List<int> citaj = new List<int>();
        string h;
        using(System.IO.StreamReader sr = new System.IO.StreamReader(@"text\brojac.txt")) 
        {
            while ((h = sr.ReadLine()) != null)
            {
                string[] parts = h.Split(',');
                if(parte. Length > 1)
                {
                    citaj.Add(int.Parse(parts[0]));
                    citaj.Add(int.Parse(parts[1]));
                } 
            } 
        } 
    } 
