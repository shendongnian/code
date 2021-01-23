    using (var context = new CRMContext())
    {
        var persons = context.Person
            .Where(p => p.Experience > 10)
            .OrderBy(p => p.DateOfBirth)
            .Select(p => new {p.StackOverFlowName, p.Experience }) //or whole object, or other fields if needed
            .ToList() //executes query, all following code will be in a context of application not DB
            .Select(p => new PersonInfo())
            {
                StackOverFlowName = p.StackOverFlowName,
                Experience = p.Experience,
                GuruStatus = GetGuruStatus(p.Experience)
            }
        return persons.ToList();
    }
    private GuruLevel GetGuruLevel(int exp)
    {
        return exp > 9000 ? GuruLevel.SuperSayan : GuruLevel.Goku
    }
