    string passwordFile = string.Empty;
    while (string.IsNullOrWhiteSpace(passwordFile))
    {
        passwordFile = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(passwordFile))
            Console.WriteLine("sorry, type again");
    }
    zip.Password = passwordFile;
