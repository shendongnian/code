        if (!String.IsNullOrEmpty(firstname))
        {
            query = query.Where(i => i.FirstName.Contains(firstname));
        }
        if (!String.IsNullOrEmpty(secondname))
        {
            query = query.Where(i => i.FirstName.Contains(firstname));
        }
        if (date!=default(DateTime))
        {
            query = query.Where(i => i.DateOfOrder==date);
        }
