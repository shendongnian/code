      private void button2_Click(object sender, EventArgs e)
        {
                if(checkBox1.Checked)
                {
                    SqlConnection sqlConnection1 = new SqlConnection(MyConString);
                    SqlCommand cmd = new SqlCommand();
                    SqlDataReader reader;
        
                    cmd.CommandText = "INSERT INTO OPENROWSET('Microsoft.ACE.OLEDB.12.0','Text;Database=D:\;HDR=YES;FMT=Delimited','SELECT * FROM [FileName.csv]') select Table1.Column from Table1 where Table1.Column1 not in (select Table2.Column2 from Table2 where Table2.Column2 = Table1.Column1)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection1;
        
                    sqlConnection1.Open();
        
                    reader = cmd.ExecuteReader();
                }
        }
