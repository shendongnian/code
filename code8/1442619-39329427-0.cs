    foreach (string studentnumber in pNumbers)
    {
        int snumber = Int32.Parse(studentnumber);
        foreach(var s in students.Where(s=>s.Id == snumber))
        { 
           presentNamesList.Add(s.FirstName + " " + s.LastName);
        }
    }
