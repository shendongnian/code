    string ConnString = getConnstring();
                string DirectoryPath = getDirectortyPath(year, quater);
                StreamWriter file = new StreamWriter(DirectoryPath);
                string StartDate = calculateStartDate(year, quater);
                string EndDate = CalculateEndDate(year, quater);
                string SqlString = "Select * from TestTable where compl_date >= @StartDate and compl_date <= @EndDate";
                using (OleDbConnection conn = new OleDbConnection(ConnString))    
                {    
                    using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@StartDate", StartDate); 
                        cmd.Parameters.AddWithValue("@EndDate", EndDate);  
                        conn.Open();
    ....          
