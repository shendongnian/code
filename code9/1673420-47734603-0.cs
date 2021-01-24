    var subjects = from subject in root.Descendants().Descendants("Keystage3")
        .Where(subject.Name.LocalName.Contains("Subject")
                          select new
                          {
                              subname = subject.Element("subjectName").Value,
                              subid = subject.Element("subjectId").Value,
                              subvalue = subject.Element("subjectvalue").Value
                          };
