    XElement root = XElement.Load("data.xml");
            var subjects = from subject in root.Descendants()
                              where subject.Name.LocalName.Contains("Subject")
                              select new
                              {
                                  SubjectName = subject.Element("subjectName").Value,
                                  SubjectId = subject.Element("subjectId").Value,
                                  SubjectValue = subject.Element("subjectvalue").Value
                              };
    foreach (var subject in subjects)
    {
        Console.WriteLine(subject);
        //you can use subject like this:
        string subjectName = subject.SubjectName;
        string subjectId = subject.SubjectId;
        string subjectValue = subject.SubjectValue;
    }
