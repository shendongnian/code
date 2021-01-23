    var psi = new ProcessStartInfo("cmd")
    {
        UseShellExecute = true,
        UserName = "username",
        Domain = "domain"
    };
    SecureString password = new SecureString();
    Console.WriteLine("Please type in the password for 'username':");
    var readLine = Console.ReadLine(); // this should be masked in some way.. ;)
    if (readLine != null)
    {
        foreach (var character in readLine)
        {
            password.AppendChar(character);
        }
        psi.Password = password;
    }
    var ps = Process.Start(psi);
