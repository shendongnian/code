    var result = list
              .OrderBy(s => s.FirstOrDefault()) // only first character
              .ThenBy(s =>
                 {
                    var stringNumber = Regex.Match(s.name, @"\d+").Value;
                    return string.IsNullOrEmpty(stringNumber) ? 0 : int.Parse(stringNumber);
                 })
