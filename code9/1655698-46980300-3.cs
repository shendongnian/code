    private void Checkbox_SelectionChanged(object sender, RoutedEventArgs e)
            {
                string connectionString = "datasource=; Port=; Username=; Password=";
    
                MySqlConnection connection = new MySqlConnection(connectionString);
                MySqlCommand AuditUpdate = new MySqlCommand("update Daily.Table set Audited='"Yes"' where ID= '" + this.txtID.Text + "'", connection);
                CheckBox checkBox = sender as CheckBox;
    
    	    foreach(MyRowItem mri in rowList)
    	    {
    		if(mri.ID == "your matching ID")
    		{
    			//something like this
    			mri.Audited = checkBox;
    		}
     	    }
    
            }
