    private IEnumerable<PersonInfo> GetGurus()
    {
        using (var context = new CRMContext())
        {
            var persons = context.Person
                .Where(p => p.Experience > 10)
                .OrderBy(p => p.DateOfBirth)
                .Select(p => new PersonInfo())
                {
                    StackOverFlowName = p.StackOverFlowName,
                    Experience = p.Experience,
                    GuruStatus = Foo(p)
                }
            return persons.ToList();
        } 
    }
