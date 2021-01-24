    var language = "fr";
    var c1 = new CultureInfo(language);
    Console.WriteLine(c1.EnglishName);              // "French"
    Console.WriteLine(c1.IsNeutralCulture);         // "True"
    Console.WriteLine((3.14m).ToString("C", c1));   // "3,14 €"
    var c2 = CultureInfo.CreateSpecificCulture(language);
    Console.WriteLine(c2.EnglishName);              // "French (France)"
    Console.WriteLine(c2.IsNeutralCulture);         // "False"
    Console.WriteLine((3.14m).ToString("C", c2));   // "3,14 €"
    var languageAndCountry = "fr-CA";
    var c3 = new CultureInfo(languageAndCountry);
    Console.WriteLine(c3.EnglishName);              // "French (Canada)"
    Console.WriteLine(c3.IsNeutralCulture);         // "False"
    Console.WriteLine((3.14m).ToString("C", c3));   // "3,14 $"
