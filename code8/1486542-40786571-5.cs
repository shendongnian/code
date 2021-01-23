    private IEnumerable<PersonInfo> GetGurus()
    {
       using (var context = new CRMContext())
       {
           var persons = context.Person
               .Where(p => p.Experience > 10)
               .OrderBy(p => p.DateOfBirth)
               .ToList()
               .Select(p => new PersonInfo(p))
           return persons.ToList();
       } 
    }
