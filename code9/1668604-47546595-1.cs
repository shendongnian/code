    public void CheckOut(object sender, EventArgs e)
    {
    	string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; // Assuming it is in your web.config
    	
    	try
    	{
    		using(MSSQLDAL dal = new MSSQLDAL(connectionString))
    		{
    			dal.BeginTransaction();
    			
    			string updateQuery = "UPDATE Content SET DateChecked=@DateChecked, CheckedOut=@CheckedOut WHERE MovieID=@MovieID";
    			
    			SqlParameter uDateChecked = new SqlParameter("DateChecked", SqlDbType.DateTime);
    			uDateChecked = DateTime.Now;
    			SqlParameter uCheckedOut = new SqlParameter("CheckedOut", SqlDbType.VarChar);
    			uCheckedOut = 'Y';
    			SqlParameter uMovieID = new SqlParameter("MovieID", SqlDbType.Int);
    			uMovieID = CheckOutList.SelectedValue;
    			
    			ICollection<SqlParameter> updateParameters = new List<SqlParameter>();
    			
    			updateParameters.Add(uDateChecked);
    			updateParameters.Add(uCheckedOut);
    			updateParameters.Add(uMovieID);
    			
    			bool updateSuccessful = dal.ExecuteNonQuery(updateQuery, updateParameters.ToArray()); 
    			
    			string insertQuery = "INSERT INTO checkout (MovieID, SubscriberID) VALUES (@MovieID, @SubscriberID)";
    
    			SqlParameter iSubscriberID = new SqlParameter("SubscriberID", SqlDbType.VarChar);
    			iSubscriberID = loginName.Text;
    			SqlParameter iMovieID = new SqlParameter("MovieID", SqlDbType.Int);
    			iMovieID = CheckOutList.SelectedValue;
    			
    			ICollection<SqlParameter> insertParameters = new List<SqlParameter>();
    			
    			insertParameters.Add(iSubscriberID);
    			insertParameters.Add(iMovieID);
    			
    			bool insertSuccessful = dal.ExecuteNonQuery(insertQuery, insertParameters.ToArray()); 
    			
    			if(updateSuccessful && insertSuccessful)
    			{
    				dal.SaveChanges();
    				
    				lblInfo.Text = "Movie Checked Out";
    			}
    			else
    			{
    				lblInfo.Text = "Something is wrong with your query!";
    			}
    		}	
    	}
    	catch(Exception ex)
    	{
    		StringBuilder sb = new StringBuilder();
    		sb.AppendLine("Error reading the database.");
    		sb.AppendLine(ex.Message);
    		if(ex.InnerException != null)
    			sb.AppendLine(ex.InnerException.Message);
    		
    		lblInfo.Text = sb.ToString();
    	}
    }
