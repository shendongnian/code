      // Expected date; invalid date; date out the range
      string source = "20-10-1950 29-02-1955 23-02-2097";
      var result = Regex
        .Matches(source, "[0-3][0-9]-[01][0-9]-[0-2][0-9]{3}")
        .OfType<Match>()
        .Select(match => {
          DateTime dt;
          bool valid = DateTime.TryParseExact(match.Value, 
            "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out dt);
          return new {
            valid = valid,
            value = dt,
          };
        })
        .Where(item => item.valid && item.value.Year <= 1998)
        .Select(item => item.value);
      // 20.10.1950 12:00:00 
      Console.Write(string.Join(Environment.NewLine, result));
