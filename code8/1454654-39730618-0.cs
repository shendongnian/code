    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace WindowsFormsApplication1
    {
        public class SQLConnect
        {
            public SQLConnect(string startUp)
            {
                startupPath = startUp;
                connectionSuccesful = false;
                OpenConnection();
            }
    
            public SqlConnection sqlConnect;
            public string startupPath { get; set; }
            public bool connectionSuccesful { get; set; }
            public bool temp { get; set; }
    
            public void IndtastBeløb(int beløb, string kategori)
            {
                DateTime time = DateTime.Now;
                int iBolig = 0; int iOther = 0; int iTransport = 0; int iLoan = 0; int iMad = 0; int iDiverse = 0;
                SqlCommand command = new SqlCommand("SELECT * FROM Entries WHERE dag = @day AND maned = @month AND ar = @year", sqlConnect); //  
    
                command.Parameters.AddWithValue("@day", time.Day);
                command.Parameters.AddWithValue("@month", time.Month);
                command.Parameters.AddWithValue("@year", time.Year);
    
                /*command.Parameters.Add("@day", SqlDbType.Int);
                command.Parameters["@day"].Value = time.Day;
                command.Parameters.Add("@month", SqlDbType.Int);
                command.Parameters["@month"].Value = time.Month;
                command.Parameters.Add("@year", SqlDbType.Int);
                command.Parameters["@year"].Value = time.Year;*/
    
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //thing = reader["bolig"].ToString();
                        //int iBolig = reader.GetInt32(0);
                        iBolig = (int)reader["bolig"];
                        iOther = (int)reader["ovrige"];
                        iTransport = (int)reader["transport"];
                        iLoan = (int)reader["gold"];
                        iMad = (int)reader["mad"];
                        iDiverse = (int)reader["diverse"];
    
                        switch (kategori)
                        {
                            case "Bolig":
                                iBolig += beløb;
                                break;
                            case "ovrige":
                                iOther += beløb;
                                break;
                            case "Transport":
                                iTransport += beløb;
                                break;
                            case "gold":
                                iLoan += beløb;
                                break;
                            case "mad":
                                iMad += beløb;
                                break;
                            case "diverse":
                                break;
                            default:
                                break;
                        }
                    }
                    reader.Close();
    
                    SqlCommand changeRow = new SqlCommand("UPDATE Entries SET bolig=@bolig WHERE dag=@day", sqlConnect); //, øvrige=@øvrige, transport=@transport, gæld=@gæld, mad=@mad, diverse=@diverse " + "WHERE dag=@day AND måned=@month AND år=@year"
                    changeRow.Parameters.AddWithValue("@bolig", iBolig);
                    changeRow.Parameters.AddWithValue("@day", time.Day);
                    /*changeRow.Parameters.AddWithValue("@øvrige", iOther);
                    changeRow.Parameters.AddWithValue("@transport", iTransport);
                    changeRow.Parameters.AddWithValue("@gæld", iLoan);
                    changeRow.Parameters.AddWithValue("@mad", iMad);
                    changeRow.Parameters.AddWithValue("@diverse", iDiverse);
    
                    changeRow.Parameters.AddWithValue("@month", time.Month);
                    changeRow.Parameters.AddWithValue("@year", time.Year);*/
    
                    int cc = changeRow.ExecuteNonQuery();
                }
                else
                {
                    temp = false;
                }
    
            }
    
    
            public void OpenConnection()
            {
                sqlConnect = new SqlConnection(@"initial catalog=StackOverflow;User Id=sa;password=xxxxxx;Server=.;");
                //sqlConnect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='c:\users\simo8211\documents\visual studio 2015\Projects\LuksusFældenForms\LuksusFældenForms\bin\Debug\LuksusDatabase.mdf';Integrated Security=True");
                try
                {
                    sqlConnect.Open();
                    connectionSuccesful = true;
                }
                catch
                {
                    connectionSuccesful = false;
                }
            }
        }
    
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        SQLConnect ocon = new WindowsFormsApplication1.SQLConnect(Application.StartupPath);
        if(ocon.connectionSuccesful)
        {
            ocon.IndtastBeløb(1, "Bolig");
        }
    }
