	public Result MyInsertMethod(...){
		var result = new Result();
		foreach (string studentID in cc.students)
		{
			SqlDataReader rdr = null;
			cmd = new SqlCommand(@"select * from CustomCohortStudent where PUID = @StudentID and cohortID = @cohortID", sqlConn);
			rdr = cmd.ExecuteReader();
			if (rdr == null)
			{
				cmd = new SqlCommand(@"insert into CustomCohortStudents(cohortID, PUID) values (@id,@StudentID)", sqlConn);
			}
			else
			{
				// code to print warning to the webpage 
				result.Warnings.Add("Something was not awesome");
			}
		}
		return result;
	}
