    static private readonly Dictionary<string, Func<customer, string>> _searches;
    static private Class() //Static constructor
    {
        _searches = new Dictionary<string, Func<customer,string>>();
        _searches.Add("City",    (c) => customer.City);
        _searches.Add("State",   (c) => customer.State);
        _searches.Add("Country", (c) => customer.Country);
    }
    protected virtual void DoSearch() //Handles the search event
    {
        var search = _searches[ComboBox.SelectedValue];
        IQueryable<customer> customers = from x in context.customers
                                         where search(x).Contains(SearchBox.Text)
                                         select x;
    }
