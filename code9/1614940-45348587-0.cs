	public string RandomString(string key = "")
    {
		var random = new Random(key.GetHashCode());
        string input = "";
        if (key.Trim() == "")
        {
            input = "abcdefghijklmnopqrstuvwxyz0123456789";
        }
        else
        {
            input = key;
        }
        var chars = Enumerable.Range(0, 5)
                               .Select(x => input[random.Next(0, input.Length)]);
        return new string(chars.ToArray());
    }
