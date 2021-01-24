    if (val1)
    {
        return ctx.Persons.ToList();
    }
    else
    {
        return ctx.Persons.Where(person => person.IsValid).ToList();
    }
