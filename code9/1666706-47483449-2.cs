    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            FeedDropDownList();
        }           
    }
    private void FeedDropDownList()
    {
        var dao = new CarDAO();
        var cars = dao.GetCars();
        ListItem empty = new ListItem(string.Empty, "0");
        empty.Selected = true;
        MyDropDownList.Items.Add(empty);
        foreach (dynamic carBrands in from c in cars
                                     group c by c.Brand into cg
                                     select new { Brand = cg.Key, Cars = cg  })
        {
            foreach(Car c in carBrands.Cars)
            {
                ListItem item = new ListItem(c.Model, c.Id.ToString());
                item.Attributes.Add("optgroup", carBrands.Brand);
                MyDropDownList.Items.Add(item);
            }
        }
    }
    protected void Dropdownlist_SelectedIndexChanged(object sender, EventArgs e)
    {
        var dropdown = sender as DropDownList;
        if (dropdown == null)
            return;
    
        var value = dropdown.SelectedValue;
    }
    
