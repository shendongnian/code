    using (var reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line == "") continue; // refuse bare lines...
                    string a = line.Split(',')[0];
                    string b = line.Split(',')[1];
                    DateTime dt = DateTime.ParseExact(line.Split(',')[2], "dd.MM.yyyy", null);
                    fileLines.Add(line); // if you want....
                }
            }
