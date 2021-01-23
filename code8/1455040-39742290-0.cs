    using (EDModell.myEntities ctx = new EDModell.myEntities())
    {
        User uNew = new User();
        uNew.FirstName = "Foo";
    
        //get your department, either by FindById, Find, Where, Single, First ...
        var department = ctx.Departments.Single(x => x.Id == 4);
        department.Users.Add(uNew);
        ctx.SaveChanges();
    }
