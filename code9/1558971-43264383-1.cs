    public void BobsLoggingFunction(string str) {
        _file.WriteLine(str);
        Console.WriteLine(str);
    }
...
    _log.BobsLoggingFunction($"My {vehicle} is full of {seaCreature}s, it is {damageDescription}");
