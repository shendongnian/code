    BindingSource bs = new BindingSource();
    private void SetSource()
    {
        bs.DataSource = personList.Where(p=>p.State != PersonState.Deleted && p.State != PersonState.New);
        grid.DataSource = bs;
    }
    public void NewPersonButton_Click()
    {
        var person = new Person();
        person.State = PersonState.New;
        personList.Add( person );
        bs.ResetBindings(false);
    }
