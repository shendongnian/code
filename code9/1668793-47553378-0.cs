    XDocument xdoc = new XDocument(
                         new XDeclaration("1.0", "utf-8", "yes"),
                         new XElement("People"));
    XElement people = xdoc.Root;
    foreach (ObservableCollection<Person> x in list)
    {
       XElement person =  new XElement("Person", fom person in x
          select new XElement("Person",
             new XElement("Name", person.Name),
             new XElement("Surname", person.Surname),
             new XElement("Age", person.Age)));
       people.Add(person);
    }
    xdoc.Save(path);
