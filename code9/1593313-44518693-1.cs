    DirectoryEntry localMachine = new DirectoryEntry("WinNT://" + 
        Environment.MachineName);
    DirectoryEntry newUser = localMachine.Children.Add("localuser", "user");
    newUser.Invoke("SetPassword", new object[] { "3l!teP@$$w0RDz" });
    newUser.CommitChanges();
    Console.WriteLine(newUser.Guid.ToString());
    localMachine.Close();
    newUser.Close();
