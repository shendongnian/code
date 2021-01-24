    List<string> remainingCountries = new List<string>(){ "US", "Germany", "Russia"};
    void RemoveIncorrectGuess(string countryToRemove)
    {
       remainingCountries.Remove(countryToRemove);
    }
