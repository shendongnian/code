    SQLReader reader;
    SQLCommand SQLCmd = new SQLCommand();
    SQLCmd.CommandText = "select Top 1 Client From _ClientName group by Client order by count(*) desc";
    SQLCmd.Connection = sqlCon.SharedDB;
    reader.Execute(SQLCmd);
