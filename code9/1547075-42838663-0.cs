	const string sqlStatement = @"Insert into ClinicalFollowUp  (MBID,  Diagnosis,   DateLastSeen,  DateofDeath ) 
	  VALUES(@MBID, @Diagnosis , @DateLastSeen, @DODeath);"
	using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Molecular"].ConnectionString))
	using (SqlCommand sc = new SqlCommand( , con))
	{
		con.Open();
		sc.Parameters.Add(new SqlParameter("@MBID", SqlDbType.VarChar, 100){Value = txtMBID1.Text});
		sc.Parameters.Add(new SqlParameter("@Diagnosis", SqlDbType.VarChar, 2000){Value = txtDiagnosis.Text.ToUpper()});
		
		// Date  Textbox
		sc.Parameters.Add(new SqlParameter("@DateLastSeen", SqlDbType.DateTime){Value = getSqlDate(txtDateLastSeen.Text)});
		// Date  Textbox
		sc.Parameters.Add(new SqlParameter("@DODeath", SqlDbType.DateTime){Value = getSqlDate(txtDateDeath.Text)});
		
		
		sc.ExecuteNonQuery();
	}
	
	// TO DO - validate culture information
	public static object getSqlDate(string dateTime)
	{
		DateTime dt;
		return !string.IsNullOrEmpty(dateTime) && DateTime.TryParse(dateTime, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt)
			? (object) dt
			: (object) System.DBNull.Value;
	}
