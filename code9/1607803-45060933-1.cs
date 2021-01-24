	// Define your database and table you want to script out
	string dbName = "Ivara77Install";
	// set up the SMO server objects - I'm using "integrated security" here for simplicity
	Server srv = new Server();
	srv.ConnectionContext.LoginSecure = true;
	srv.ConnectionContext.ServerInstance = ".";
	// get the database in question
	Database db = new Database();
	db = srv.Databases[dbName];
	StringBuilder sb = new StringBuilder();
	// define the scripting options - what options to include or not
	ScriptingOptions options = new ScriptingOptions();
	options.ClusteredIndexes = true;
	options.Default = true;
	options.DriAll = true;
	options.Indexes = true;
	options.IncludeHeaders = true;
    
	// script out the table's creation 
	Table tbl = db.Tables.OfType<Table>().Single(t => t.Schema.ToLower() == "exd" && t.Name.ToLower() == "ABCINDICATORSET".ToLower() );
	StringCollection coll = tbl.Script(options);
	foreach (string str in coll)
	{
		sb.Append(str);
		sb.Append(Environment.NewLine);
	}
	// you can get the string that makes up the CREATE script here
	// do with this CREATE script whatever you like!
	string createScript = sb.ToString();
