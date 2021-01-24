    XElement items = xdoc.Root
    foreach (ObservableCollection<Person> x in list)
    {
        XElement smallList= new XElement("List");
        items.Add(smallList);
        foreach (var person in x)
        {
            XElement person = new XElement("Person",
                new XElement("Name", person.name),
                new XElement("Surname", person.surn),
                new XElement("City", person.city));
            smallList.Add(person);
        }
    }
    xdoc.Save(path);
