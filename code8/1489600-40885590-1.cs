    var person = new Person();
    foreach (var line in lines)
       {
       Char delimiter = '=';
       string[] contents = line.Split(delimiter);
       switch(contents[0])       
          {         
             case "person":  
                if(person.id != Convert.ToInt32(contents[1]))
                   {
                       list.Add(person);
                       person = new Person();
                   }
                person.id = Convert.ToInt32(contents[1]);
                break;  
             case "name ":   
                person.name = contents[1];
                break;  
             case "sirname":            
                person.sirname = contents[1];
                break; 
    		//...etc
           }
       }
