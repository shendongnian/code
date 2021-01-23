    class CyClass
    {
        private struct Person { public string Name; }
        
        HashSet<Person> hashSet = new HashSet<Person>();
    
        ...
    
            using (var new Scope())
            {
                hashSet.Add(new Person { Name = "Boaty" });
                hashSet.Add(new Person { Name = "McBoatface" });
            }
        
            using (var new AnotherScope())
            {
                return names.Where(x => hashSet.Contains(new Person{ x.Name }));
            }
    }
