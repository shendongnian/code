    public static string ToTitleCase(this string input)
    {
        string output = 
          String.Join(" ", input.Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries)
                        .ToList()
                        .Select(x => x = x.Length>1?
                                     x.First().ToString().ToUpper() + x.Substring(1): 
                                     x.First().ToString().ToUpper()));
        output = 
          String.Join(".", output.Split(new char[] { '.' },StringSplitOptions.RemoveEmptyEntries)
                            .ToList()
                            .Select(x => x = x.Length > 1 ?
                                    x.First().ToString().ToUpper() + x.Substring(1) : 
                                    x.First().ToString().ToUpper()));
        return output;
    }
