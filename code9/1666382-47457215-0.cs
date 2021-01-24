    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            NorthwindEntities entity = new NorthwindEntities();
            var db1 = (from ordermst in entity.Orders
                        where ordermst.ShipCountry.Equals("Finland")
                        select new
                        {
                            CustomerID = ordermst.CustomerID,
                            OrderID = ordermst.OrderID
                        }).Take(10).ToList();
            DataTable dt = ConvertToDataTable(db1);
            GvOrder.DataSource = dt;
            GvOrder.DataBind();
     
            DataTable dt1 = new DataTable();
            dt1 = GvOrder.DataSource as DataTable;
            GvOrder1.DataSource = dt1;
            GvOrder1.DataBind();
     
        }
    }
     
    private DataTable ConvertToDataTable<T>(IList<T> data)
    {
        PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
        DataTable table = new DataTable();
        foreach (PropertyDescriptor prop in properties)
        {
            table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
        }
        foreach (T item in data)
        {
            DataRow row = table.NewRow();
            foreach (PropertyDescriptor prop in properties)
            {
                row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
            }
            table.Rows.Add(row);
        }
        return table;
    }
