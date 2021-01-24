    public void Write(string str) {
        _file.WriteLine(str);
        Console.WriteLine(str);
    }
...
    _log.Write($"My {vehicle} is full of {seaCreature}s, it is {damageDescription}");
