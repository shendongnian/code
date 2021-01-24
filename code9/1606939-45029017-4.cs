    public  void  Fillcombo()
            {
                string oradb = " Data Source=xe;User Id=dbname;Password=pws; ";
                string query = "select id , name from table";
                OracleConnection condatabase = new OracleConnection(oradb);
                OracleCommand cmddatabase = new OracleCommand(query, condatabase);
                
                try
                {
                    condatabase.Open();
                    OracleDataReader myReader = cmddatabase.ExecuteReader(); ;
                    myReader = cmddatabase.ExecuteReader();
                    while (myReader.Read())
                    {
                        string sname = myReader.GetInt32(0).ToString();
                        comboBox1.Items.Add(sname.ToString());
                    }
    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
