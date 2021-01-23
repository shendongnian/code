        var person = new Person();
        foreach (var line in lines)
            {
               Char delimiter = '=';
               string[] contents = line.Split(delimiter);
               if (contents[0].StartsWith("name")) 
               { 
                  person.name = contents[1]; 
               } 
               if (contents[0].StartsWith("sirname")) 
               { 
                  person.sirname = contents[1]; 
               } 
               if (contents[0].StartsWith("id")) 
               { 
                  person.id = contents[1];  
               }
               if (contents[0].StartsWith("nationality")) 
               { 
                  person.id = contents[1];  
                  list.Add(person);
                  person = new Person();
               }
            }
