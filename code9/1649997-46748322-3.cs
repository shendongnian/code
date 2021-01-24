    public void RunFile()
    {
        var ctx = new YourContext();
        var commands = new List<IMyCommand>();
        // You could look for all ICommand implementations here with reflection or just hard-code all known classes...
        command.Add(new Move() { Context = ctx; });
        command.Add(new Wait() { Context = ctx; });
        var lines = File.ReadAllLines("your-file.txt");
        foreach(var line in lines)
        {
            var cmd = commands.FirstOrDefault(x => x.IsResponsible(line));
            if (cmd == null)
                throw new IOException("unknown command!");
            cmd.Execute(line);
        }
    }
