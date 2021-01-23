    public void Main()
    {
    	DataSet Custumers = new DataSet("Custumers");
    	DataTable Custumer = new DataTable("Custumer");
    
    	// Create the columns
    	Custumer.Columns.Add("id", typeof(int)).Unique = true;
    	Custumer.Columns.Add("name", typeof(string));
    	Custumer.Columns.Add("gender", typeof(string));
    	Custumer.Columns.Add("etc", typeof(string));
    
    	// Set the primary key
    	Custumer.PrimaryKey = { Custumer.Columns("id") };
    
    	// Add table to dataset
    	Custumers.Tables.Add(Custumer);
    	Custumers.AcceptChanges();
    
    	// Add a couple of rows
    	Custumer.Rows.Add(1, "John", "male", "whatever");
    	Custumer.Rows.Add(2, "Jane", "female", "whatever");
    	Custumer.AcceptChanges();
    
    	// Let's save this to compare to the updated version
    	Custumers.WriteXml("Custumers_Original.xml");
    
    	// Read in XML that contains an existing Custumer and adds a new one
    	//	into a Clone of the Custumer table
    	DataTable CustumerUpdate = Custumer.Clone;
    	CustumerUpdate.ReadXml("Custumers_Update.xml");
    
    	// Merge the clone table data to the Custumer table
    	Custumer.Merge(CustumerUpdate);
    	Custumer.AcceptChanges();
    
    	Custumers.WriteXml("Custumers_Final.xml");
    }
