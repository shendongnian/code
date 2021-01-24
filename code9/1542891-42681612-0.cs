    IQueryable<Phone> someQueryable = null;
    
        if (match.Success)
        {
            someQueryable = from g in db.Phones
                where g.GovAllowed == true
                select g;
        }
        else
        {
            someQueryable = from c in db.Phones
                where c.CommerceAllowed == true
                select c;
        }
    
       return someQueryable.ToList();
            
