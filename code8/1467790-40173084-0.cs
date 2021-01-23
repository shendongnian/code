    bool ContainsOnlyDigitsAndLetters(string source)
    {
        int letters = myInput.Count(Char.IsLetter);
        int numbers = myInput.Count(Char.IsDigit);
        return letters != 0 && numbers != 0 && letters + numbers == myInput.Length;
    }
