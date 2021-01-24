    XElement items = xdoc.Root
    XElement bigList= new XElement("List");
    items.Add(bigList);
    foreach (ObservableCollection<Person> x in list)
    {
        foreach (var person in x)
        {
            XElement person = new XElement("Person",
                new XElement("Name", person.name),
                new XElement("Surname", person.surn),
                new XElement("City", person.city));
            bigList.Add(person);
        }
    }
    xdoc.Save(path);
