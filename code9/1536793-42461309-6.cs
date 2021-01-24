        List<string> hiscores = new List<string>();
        StreamReader sr = new StreamReader("C:\\Users\\BS\\Desktop\\tex.txt");
        string g = sr.ReadLine();
        while (g != null)
        {
            hiscores.Add(g);
            g = sr.ReadLine();
        }
        sr.Close();
        hiscores.Sort();
        hiscores.Reverse();
        //alternatively, instead of Sort and then reverse, you can do
        //hiscores.OrderByDescending(x => x);
        foreach(string s in hiscores)
        {
    	    listBox1.Items.Add(s);
        }
