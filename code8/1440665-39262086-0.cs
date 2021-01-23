    public enum Gender { Male, Female }
    private Dictionary<string, Gender> _mapping = new Dictionary<string, Gender> {
        ["Name One"] = Gender.Male,
        ["Name Two"] = Gender.Female,
    };
    // now do something with _mapping[name]
