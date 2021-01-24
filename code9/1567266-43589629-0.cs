    List<CountryScript> countryList = new  List<CountryScript>();
    countryList.AddRange(GetComponents<CountryScript>());
    List<CountryScript> shuffledCountryList = new  List<CountryScript>();
    while(countryList.Count > 0) {
        CountryScript c = countryList[Random.Range(0, countryList.Count)];
        shuffledCountryList.Add(c);
        countryList.Remove(c);
    }
