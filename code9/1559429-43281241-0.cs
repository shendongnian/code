       public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }
            public override string ToString()
            {
                return Text;
            }
        }
		
	 protected void Page_Load(object sender, EventArgs e)
    {
        DataConnector dc = new DataConnector();
        DropDownList1.DataSource = dc.getCodeTypes();
	    ComboboxItem item = new ComboboxItem();
                item.Text = "id"
                item.Value = "description";
                DropDownList1.Items.Add(item);
    }
