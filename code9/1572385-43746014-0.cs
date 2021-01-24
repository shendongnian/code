    string constring = "Data Source=TS-ERP01;Initial Catalog=Touchstn02;Integrated Security=True";
    string Query = "select * from  Defect_Codes Where DESCP_91= @ds91";
    using(SqlConnection conDataBase = new SqlConnection(constring))
    using(SqlCommand cmdDataBase = new SqlCommand(Query, conDataBase))
    {
       try
       {
           conDataBase.Open();
           cmdDataBase.Parameters.Add("@ds91", SqlDbType.NVarChar).Value = ddDefect.Text;
           using(SqlDataReader myReader = cmdDataBase.ExecuteReader())
           {
               while (myReader.Read())
               {
                  string sDEF = myReader["DEFECT_91"].ToString();
                  txtNcm.Text = sDEF;
               }
           }
       }
       catch (Exception ex)
       {
           MessageBox.Show(ex.Message);
       }
    }
