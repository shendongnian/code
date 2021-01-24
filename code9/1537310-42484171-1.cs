    public void Add1()
    {
        newprospect = new Prospect();
        newprospect.ID = Guid.NewGuid();
        newprospect.FirstName = FirstName;
        newprospect.LastName = LastName;
        newprospect.Address = Address;
        newprospect.State = State;
        newprospect.City = City;
        newprospect.ZIP = ZIP;
        prospect = newprospect;
        ctx2.AddToProspects(prospect);
        Prospects.Add(newprospect);
    }
