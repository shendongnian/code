        var person = new Person();
        for (int i=1; i < lines.Count; i+=12)
            {
                if (lines[i].StartsWith("name"))
                {
                    person.name = lines[i].Split('=')[1];
                }
                if (lines[i+1].StartsWith("sirname"))
                {
                    person.sirname = lines[i+1].Split('=')[1];
                } 
                if (lines[i+2].StartsWith("id"))
                {
                    person.id = lines[i+2].Split('=')[1];
                }
                if (lines[i+3].StartsWith("nationality"))
                {
                    person.nationality = lines[i+3].Split('=')[1];
                }
                try //optional element
                {
                    if (lines[i + 4].StartsWith("whatever"))
                    {
                        person.whatever = lines[i + 4].Split('=')[1];
                        i += 1;
                        list.Add(person);
                        person = new Person();
                        continue;
                    }
                    else
                    {
                        break; //fileformat not supported
                    }
               catch 
               {
                    list.Add(person);
                    person = new Person();
                }
            }
