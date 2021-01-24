    StreamReader SR = new StreamReader(@"test.txt");
    for (int i = 0; i < 10; i++)
    {
        test[i] = SR.ReadLine();
        DateTime time = DateTime.ParseExact(test[i], "HH:mm:ss", CultureInfo.InvariantCulture);
    }
