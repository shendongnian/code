        try
        {
			SqlParameter errNumber = new SqlParameter("@errNumber", 0);
			SqlParameter errLine = new SqlParameter("@errLine", 0);
			SqlParameter errMessage = new SqlParameter("@errMessage", "");
            Command.ExecuteNonQuery();
			int SqlError = (int)(errNumber.Value);
			int SqlLine = (int)(errNumber.Value);
			string SqlMessage = (string)errMessage.Value;
			if (SqlError == 0 ) { Success = true; }
			else {
			    Success = false;
			    // whatever else you want to do with the error data
			}
        }
