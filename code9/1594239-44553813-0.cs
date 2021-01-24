    private ICollection<Student> FilterStudents(ICollection<Student> students)
    {
        var query = students.AsQueryable();
    
        if (ColonieFilterCheckBox.Checked)
        {
           query  = query.Where(x=>x.Colonie);
        }
    
        if (NatationFilterCheckBox.Checked)
        {
            query  = query.Where(x=>x.Nation);
        }
    
        if (ExcursionFilterCheckBox.Checked)
        {
            query  = query.Where(x=>x.Excursion);
        }
    
       return query.ToList();
    }  
