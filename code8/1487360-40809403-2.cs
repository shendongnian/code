    int counter = 0;
    string line;
    using(var file = new System.IO.StreamReader(arg))
    {
        while((line = file.ReadLine()) != null)
        {
            Console.WriteLine (line);
            counter++;
        }
    }
