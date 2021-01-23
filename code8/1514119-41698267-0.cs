    public string imie
    {
        get { ... }
        set {
            _imie = new string(value.Where(c => char.ToLower(c) >= 'a' && char.ToLower(c) <= 'z').Select(c => char.ToLower(c)).ToArray());
        }
    } 
