    string[] arrayToSearch = new string[3] {
        "OTHER STUFF",
        "CANASTA              PIPPO",
        "MORE STUFF"
    };
    string stringToFind = "PIPPO CANASTA PER  FT 501 del 1/11/2016";
    string[] wordsToFind = stringToFind.Split(default(Char[]), StringSplitOptions.RemoveEmptyEntries);
    string bestMatch = arrayToSearch.OrderByDescending(
        s => s.Split(default(Char[]), StringSplitOptions.RemoveEmptyEntries)
              .Intersect(wordsToFind, StringComparer.OrdinalIgnoreCase)
              .Count()
    ).FirstOrDefault();
    Console.WriteLine("Best match: " + bestMatch);
    Console.ReadKey();            
