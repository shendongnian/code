    var sections = new List <IGenerateXml>() 
    {
        new GenerateSection1(),
        new GenerateSection2(),
        new GenerateSection3()
    }
    foreach(var section in sections)
    {
        section.Student = _student;
        section.Course = _course;
        section.User = _user;
    }
