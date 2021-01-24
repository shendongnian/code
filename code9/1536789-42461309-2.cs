        List<string> hiscores = new List<string>();
        StreamReader sr = new StreamReader("C:\\Users\\BS\\Desktop\\tex.txt");
        string g = sr.ReadLine();
        while (g != null)
        {
            hiscores.Add(g);
        }
        sr.Close();
        hiscores.Sort();
        foreach(string s in hiscores)
        {
    	    listBox1.Items.Add(s);
        }
