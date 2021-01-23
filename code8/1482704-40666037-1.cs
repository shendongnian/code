        List<int> citaj = new List<int>();
        string h;
        using(System.IO.StreamReader sr = new System.IO.StreamReader(@"text\brojac.txt")) 
        {
            while ((h = sr.ReadLine()) != null)
            {
                int number = 0;
                if (int.TryParse(h, out number)) 
                    citaj.Add(number);
            } 
        } 
    } 
