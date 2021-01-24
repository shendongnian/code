    Country selectedCountry = country.SingleOrDefault(x => x.Name == selectedCountry);
    if (selectedCountry != null) {
        Console.WriteLine(selectedCountry.Name);
        foreach (string flagColor in selectedCountry.FlagColors) {
            Colors color = color.SingleOrDefault(x => x.Name == flagColor);
            if (color != null) {
                Console.WriteLine(color.Name + " " + color.Hex);
            }
        }
    }
