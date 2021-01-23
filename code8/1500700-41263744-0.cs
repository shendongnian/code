       Cmd = Con.CreateCommand(); //This hooks up the connection to this command
       Cmd.CommandText = "[dbo].[aaa]";
       Cmd.CommandType = CommandType.StoredProcedure;
       Cmd.Parameters.Add("@bbb", SqlDbType.Int).Value = 1;
       Cmd.Parameters.Add("@LettType", SqlDbType.VarChar, 3).Value = LetterType;
       Cmd.Parameters.Add("@IsTajamo", SqlDbType.Char, 1).Value = 1;
       Da = new SqlDataAdapter(Cmd); //Just the command
       Dt.Clear();
       Da.Fill(Dt);
