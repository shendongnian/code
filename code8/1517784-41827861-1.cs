     DataTable table = new DataTable("Table");
     table.Columns.Add("Site", typeof(string));
     table.Columns.Add("ChassisName", typeof(string));
     table.Columns.Add("IP", typeof(string)); 
    
     table.Rows.Add("Rear Port", "Management", "192.168.1.1");
     table.Rows.Add("Front USB", "Local", "10.10.10.1");
    
     dgv.DataSource = table;
