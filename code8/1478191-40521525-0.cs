    // Fill data table (you should do it from xml file)
    var dt1 = new DataTable("empl");
    dt1.Columns.Add("empl_num");
    dt1.Columns.Add("Name");
    dt1.Rows.Add(1, "Carl");
    dt1.Rows.Add(2, "Mark");
    dt1.Rows.Add(3, "Tanner");
    // Fill second data table
    var dataSet = new DataSet();
    using (var xmlReader = XmlReader.Create("test.xml"))
    {
        xmlReader.ReadToFollowing("Data2");
        dataSet.ReadXml(xmlReader);
    }
    // Set a relation between two tables
    dataSet.Tables.Add(dt1);
    dataSet.Relations.Add("FK", dt1.Columns["empl_num"],
        dataSet.Tables[0].Columns["ID_NUM"]);
    var bs1 = new BindingSource();
    bs1.DataSource = dataSet;
    bs1.DataMember = "empl";
    var bs2 = new BindingSource();
    bs2.DataSource = bs1;
    bs2.DataMember = "FK"; // note to foreign key
    // Bind sources to grids
    dataGridView1.DataSource = bs1;
    dataGridView2.DataSource = bs2;
