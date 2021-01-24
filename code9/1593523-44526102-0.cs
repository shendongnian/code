	string inProgressQuery = "SELECT TOP 10 IDType, ID, Program, Date, Body, 
                          AcctNo, ANPACAcctID, ANPACClientID, TEAMID, 
                          ImportDate, AnnualReview, TeamGUID, 
                          ANPACClientLastName, ANPACClientFirstName, " +
                          "PolicyNumber, AccountOwnerLastName, 
                           AccountOwnerFirstName, SCRACF, SCDateTime, NoteID 
                           FROM NoteTable WHERE SQLMigrationFl = ?";
	using(var command = new OleDbCommand(inProgressQuery, connection))
	{
		// I guessed on the type and length
		command.Parameters.Add(new OleDbParameter("SQLMigrationFl", OleDbType.VarChar, 10)).Value = "I";
		using(var reader = command.ExecuteReader())
		{
			while(reader.Read())
			{
				//clear the In Progress flag
				const string UpdateQuery = "UPDATE NoteTable SET SQLMigrationFl = ? WHERE NoteTable.NoteID = ?";
				using(var commandUpdate = new OleDbCommand(UpdateQuery, connection))
				{
					commandUpdate.Parameters.Add(new OleDbParameter("SQLMigrationFl", OleDbType.VarChar, 10)).Value = DBNull.Value;
					commandUpdate.Parameters.Add(new OleDbParameter("NoteId", OleDbType.Int)).Value = reader[19];
					commandUpdate.ExecuteNonQuery();
				}
			}
		}
	}
	
