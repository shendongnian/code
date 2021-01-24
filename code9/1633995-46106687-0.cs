    using (var userEntry = new DirectoryEntry("WinNT://" + Environment.MachineName + '/' + Environment.UserName + ",user"))
    {
        int secondsSinceLastChange = (int)userEntry.InvokeGet("PasswordAge");
        int daysSinceLastChange = secondsSinceLastChange / 60 / 60 / 24;
    
        Console.WriteLine("{0} days since your last password change.", daysSinceLastChange);
    }
