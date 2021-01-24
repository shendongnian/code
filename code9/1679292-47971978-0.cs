    using (StreamWriter writer = new StreamWriter("temp.txt"))
    {
        for (int i = 0; i < 1000; i++)
        {
            writer.WriteLine(i.ToString());
        }
    }
