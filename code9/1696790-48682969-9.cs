    int myStudentId = ...
    MyDbContext myDbContext = ...
    DisplayedValue birthday = new Display<DateTime>()
    {
        Id = myStudentId,
        FieldDescription = "Birthday",
        // Parse function to parse the update string to a DateTime
        Parse = (txt) => DateTime.Parse(txt),
        // function to parse the DateTime to a displayable string
        ToDisplayValue = (birthday) => birthDay.ToString("yyyy/MMM/DD"),
        // the function that fetches the Birthday of Student with Id from myDbContext:
        FetchValue = (id) => myDbContext.Students
            .Where(student => student.Id == id)
            .Select(student => student.Birthday)
            .SingleOrDefault();
        // the function that updates the Birthday of the Student with Id from myDbContext:
        UpdateValue = (id, valueToUpdate) =>
        {
             Student studentToUpdate = dbContext.Students
                 .Where(student => student.Id == id)
                 .SingleOrDefault();
             studentToUpdate.BirthDay = valueToUpdate);
             myDbContext.SaveChanges();            
        },
    }
