    List<string> CompareList = new List<string>();
            //...however you're gonna loop this
            string LastName = input.Substring(12, 10);
            string FirstName = input.Substring(21, 21);
            string generatedName = LastName.Substring(0, 4) +
                                   FirstName.Substring(0, 4);
            bool nameIsUnique = true;
            foreach (var entry in CompareList)
            {
                if (entry == generatedName) nameIsUnique = false;
            }
            if (nameIsUnique) CompareList.Add(generatedName);
            else //Go back to generating a name, add a number on the end, etc
            //Go to next line in your text file, rinse, repeat.
        
