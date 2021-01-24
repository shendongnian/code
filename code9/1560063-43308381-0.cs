    using(var sr = new StreamReader(fileInput))
    while ((line = sr.ReadLine()) != null) {
        if (line.Contains(mK)) // <---Variable inputted by the user
        {
            var value = line.Split(",")[0];
            Console.WriteLine(value);
        }
    }
