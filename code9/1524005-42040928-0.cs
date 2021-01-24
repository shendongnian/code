    using System.Data;
    using MySql.Data.MySqlClient;
    
    var timeIn = blabla;
    var eID = lblEID.Text;
    //var blablabla = blablabla; 
    var query = @"UPDATE mia_payroll.tbl_attendance SET TimeIn = @TimeIn, Date = @Date, EID = @EID"; //are you missing a WHERE clause? otherwise you will update all row. maybe you want to do something like below.
    //var query = @"UPDATE mia_payroll.tbl_attendance SET TimeIn = @TimeIn, Date = @Date, EID = @EID WHERE rowID = @rowID";
    using(MySqlConnection myConn = new MySqlConnection(ConnectionClass.GetConnection()))
    using(MySqlCommand cmDB = new MySqlCommand(query, myConn))
    {
        try
        {
            //for your question to me about adding parameters value, just keep adding.
            cmDB.Parameters.AddWithValue("@TimeIn", timeIn);
    	    cmDB.Parameters.AddWithValue("@eID", eID);
    	    //cmDb.Parameters....... and so on
    	    //now execute query
    	    myConn.Open();
    	    using(MySqlDataReader myReader = cmDB.ExecuteReader())
    	    {
    	        while(myReader.Read())
    	        {
    		         //do what you want with your result.
    		    }
    	    }
        }
        catch (Exception ex)
        {
    	    MessageBox.Show(ex.Message);
        }
        finally
        {
    	    myConn.Close();
        }
    }
