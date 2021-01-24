    DataTable dtMembers = new DataTable();
    p.textquery = "SELECT * FROM members ORDER BY member_id DESC LIMIT 250";
    SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + p.dbname() + ";Version=3;");
    try
    {
    	SQLiteDataAdapter da = new SQLiteDataAdapter(p.textquery,m_dbConnection);
    	m_dbConnection.Open();
    	da.Fill(dtMembers);
    	m_dbConnection.Close();
    	if(dtMembers.Rows.Count > 0)
    		dgvMembers.DataSource = dtMembers;
    	else
    		p.alert("You do not have members in the system");
    }
    catch
    {
    	p.alert("SQL has error - (database error)");
    	return;
    }
