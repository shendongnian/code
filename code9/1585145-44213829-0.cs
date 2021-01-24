    if (this.IsPostBack)
    {
        if (Request["__EVENTTARGET"] == "_storeDetails")
        {
            // This can fail if you pass a value which is not an integer
            // You can use TryParse instead if you want.
            int param = int.Parse(Request["__EVENTARGUMENT"]);
            _storeDetails(param);
        }
    }
