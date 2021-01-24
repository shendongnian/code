            string filePath = ""; //Your file path goes here
            string[] lines = File.ReadAllLines(filePath);
            string newLastName = "Smith";
            string newFirstName = "John";
            for (int i = 0; i < lines.Count(); i++)
            {
                if (lines[i].Contains("nameL="))
                    lines[i] = "nameL=" + newLastName;
                if (lines[i].Contains("nameF="))
                    lines[i] = "nameF=" + newFirstName;
            }
            File.WriteAllLines(filePath, lines);
