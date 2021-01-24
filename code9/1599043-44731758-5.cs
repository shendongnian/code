    static private readonly Func<customer, string>[] _searches;
    static private Class() //Static constructor
    {
        _searches = new Func<customer,string>[]
        {
            (c) => customer.City,
            (c) => customer.State,
            (c) => customer.Country 
        }
    }
    protected virtual void DoSearch() //Handles the search event
    {
        var search = _searches[ComboBox.SelectedIndex];
        IQueryable<customer> customers = from x in context.customers
                                         where search(x).Contains(SearchBox.Text)
                                         select x;
    }
