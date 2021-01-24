    string[] columns; // populate this somehow: e.g., read the header.
    // create the FileHelpers record class
    // alternatively there is a 'FixedClassBuilder'
    DelimitedClassBuilder cb = new DelimitedClassBuilder("Customers", ","); 
    cb.IgnoreFirstLines = 1; 
    cb.IgnoreEmptyLines = true; 
    
    // populate the fields based on the columns
    foreach (string column in columns)
    {
         cb.AddField(column, typeof(string)); 
         cb.LastField.TrimMode = TrimMode.Both;
    }
    
    // load the dynamically created class into a FileHelpers engine
    FileHelperEngine engine = new FileHelperEngine(cb.CreateRecordClass());
    
    // import your records
    DataTable dt = engine.ReadFileAsDT("testCustomers.txt"); 
