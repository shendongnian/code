    set
    {
        foreach (var letter in value)
        {
            if (char.IsLetter(letter))
            {
                _imie += char.ToLower(letter);
            }
        }
    }
