    string passwordFile = string.Empty;
    while (string.IsNullOrWhiteSpace(passwordFile))
    {
        passwordFile = Console.ReadLine();
        if (passwordFile == "")
            Console.WriteLine("sorry, type again");
    }
    zip.Password = passwordFile;
