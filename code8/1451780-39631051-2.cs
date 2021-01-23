        private void sqlCon(List<string> x)
        {
            //Replace with your server credentials/info
            SqlConnection myConnection = new SqlConnection("user id=username;" +"password=password;server=serverurl;" +"Trusted_Connection=yes;" +"database=database; " + "connection timeout=30");
            try
            {
                myConnection.Open();
                for (int i = 0; i <= x.Count -4; i += 4)//Implement by 3...
                {
                    //Replace table_name with your table name, and Column1 with your column names (replace for all).
                    SqlCommand myCommand = new SqlCommand("INSERT INTO table_name (Column1, Column2, Column3, Column4) " +
                                         String.Format("Values ('{0}','{1}','{2}','{3}')", x[i], x[i + 1], x[i + 2], x[i + 3]), myConnection);
                    myCommand.ExecuteNonQuery();
                }
            }
            catch (Exception e){Console.WriteLine(e.ToString());}
            try{myConnection.Close();}
            catch (Exception e){Console.WriteLine(e.ToString());}
        }
