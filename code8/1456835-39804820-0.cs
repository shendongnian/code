    string[] names = new[] {"name1", "name2", "name3"}; // sample array
    void Update(){
        int index = names.indexOf(currentCharacterName);
        var framesByName = names.Skip(index * 3).Take(3).ToArray();
    }
