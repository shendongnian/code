    string text = "foobar";
    for (int i = 0; i < 10; i++)
    {
        text = Convert.ToBase64String(Encoding.ASCII.GetBytes(text));       
        Console.WriteLine(text);
    }
