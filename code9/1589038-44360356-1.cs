    		if (textBox1.Text != "")
		{
			//retrieve data
			string sTown, sMonth, sYear;
			sTown = textBox1.Text.Substring(0, 3);
			sMonth = textBox1.Text.Substring(3, 2);
			sYear = textBox1.Text.Substring(5);
			//validate input
			bool valid_town = new Regex(@"[a-z]", RegexOptions.IgnoreCase).IsMatch(sTown) && new Regex(@"[^0-9]").IsMatch(sTown) && sTown.Length ==3;
			bool valid_month = new Regex(@"[0][1-9]|[1][0-2]").IsMatch(sMonth) && new Regex(@"[^a-z]", RegexOptions.IgnoreCase).IsMatch(sMonth) && sMonth.Length ==2;
            int year = 0;
            bool isNum = int.TryParse(sYear,out year);
            bool valid_year = new Regex(@"[^a-z]", RegexOptions.IgnoreCase).IsMatch(sYear) && sYear.Length == 4 && (isNum ? year > 1980 && year < 2100 : false);
            string newLine = System.Environment.NewLine;
            
            //if input valid
            if (valid_town && valid_month && valid_year)
            {
                //create sql statements
                string sWhere = String.Format("WHERE Town LIKE {0} and month(TownDate) = {1] and year(TownDate) = {2}", sTown,sMonth,sYear);
                string sCount = String.Format("SELECT COUNT(*) FROM Country {0}", sWhere);
                string sDelete = String.Format("DELETE * FROM Country {0}",sWhere);
                //counts; to be deleted, actually deleted
                int initialCount = 0;
                int deletedCount = 0;
                try
                {
                    //create connection//NOTE: Using 'Use' statement will handle opening and closing. I dont know where you created your initial 'connection' object but it could cause you problems by haven a connection that is being used in multiple methods.
                    using (OleDbCommand connection = new OleDbCommand(ConnectionString))
                    {
                        //get total rows to be affected
                        connection.CommandText = sCount;
                        initialCount = connection.ExecuteNonQuery();
                        //delete rows and get delete count
                        connection.CommandText = sDelete;
                        deletedCount = connection.ExecuteNonQuery();
                        //display message
                        MessageBox.Show(String.Format("Found {0} rows to delete. {1}Deleted {2} rows.", initialCount, newLine, deletedCount));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
            {
                //else; input not valid
                MessageBox.Show(String.Format("Failed validation of TextBox:{0}Country:{1}{2}Month{3}{4}Year{5}.", newLine, valid_town.ToString(), newLine, valid_month.ToString(), newLine, valid_year.ToString())); ;
            }
        }
		else
		{
			MessageBox.Show("TextBox is empty!");
		}
