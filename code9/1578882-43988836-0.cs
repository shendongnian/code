    //using (var writer = new StringWriter())
    using (var writer = new StreamWriter("test.txt"))
    {
        var regex = new Regex("(?<=\\G.{20})");
        foreach (var item in list)
        {
            var splitted = regex.Split(item.Name);
            writer.WriteLine("{0,-20}\t{1}\t{2}", splitted[0], item.Price1, item.Price2);
            for (int i = 1; i < splitted.Length; i++)
                writer.WriteLine(splitted[i]);
        }
        //Console.WriteLine(writer.ToString());
    }
