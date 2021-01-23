    using (MyDbContext ctx = new MyDbContext())
    {
        Standard std = new Standard();
    
        Student stud = new Student()
        {
            StudentName = "John",
        };
        
        stud.Standard = std;
        
        ctx.Student.Add(stud);
        ctx.SaveChanges();
    }
