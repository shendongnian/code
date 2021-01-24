    DisplayFactory factory = new DisplayFactory()
    {
        MyDbContext = ...
    }
    DisplayedValue createdValue = factory.Create(id,
       student => student.Birthday,                   // property selector
       (student, value) => student.Birthday = value;  // property updater
       (txt) => DateTime.Parse(txt),                  // string to Datetime
       (birthday) => birthDay.ToString(...));          // to displayed birthday
       
