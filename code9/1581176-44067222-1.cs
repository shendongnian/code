    public List<MyClass> returnData()
            {
               
              
                List<MyClass> returningdata = new List<MyClass>();
    
                Person pers = new Person();
                pers.City = "NELSPRUIT";
                pers.Name = "TED";
                pers.ID = "5502226585665";
                pers.Type = "PERSON";
    
                returningdata.Add(pers);
    
                Dog doggy = new Dog();
                doggy.Name = "Tiny";
                doggy.Age = 2;
                doggy.Type = "DOG";
    
                returningdata.Add(doggy);
    
                return returningdata;
            }
