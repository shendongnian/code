    using (var rdr = OpenReadFile(...))
    using (var wtr = OpenWriteFile(...)) {
      string line;
      while ((line = rdr.ReadLine()) != null) {
        line = line.Replace(x, y);
         str.WriteLine(line);
      }
    }
