    //create the DataTable
    DataTable dt = new DataTable("Contact");
    public Form1()
    {
        InitializeComponent();
        //create columns for the DataTable
        DataColumn dc1 = new DataColumn("Id");
        dc1.DataType = System.Type.GetType("System.Int32");
        dc1.AutoIncrement = true;
        dc1.AutoIncrementSeed = 1;
        dc1.AutoIncrementStep = 1;
        //add columns to the DataTable
        dt.Columns.Add(dc1);
        dt.Columns.Add(new DataColumn("Name"));
        dt.Columns.Add(new DataColumn("Age"));
        dt.Columns.Add(new DataColumn("Gender"));
    }
    private void buttonCreate_Click(object sender, EventArgs e)
    {   
        DataRow row = dt.NewRow();
        row["Name"] = textBoxName.Text;
        row["Age"] = textBoxAge.Text;
        row["Gender"] = textBoxGender.Text;
        dt.Rows.Add(row);
        dataGridView1.DataSource = dt;
        //create DataSet
        DataSet ds = new DataSet();
        ds.DataSetName = "AddressBook";
        ds.Tables.Add(dt);
        ds.WriteXml("Contacts.xml");
    }
