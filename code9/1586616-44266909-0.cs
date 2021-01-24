    public Form2(int ID)
     {
      InitializeComponent();
      Entities CustomerContext = new Entities(entityConnectionStringBuilder.ToString());
      var query = CustomerContext.Customers.Where(a => a.id == ID);
      CustBindingSource1.DataSource = query.ToList();
     }
