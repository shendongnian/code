         protected void Page_Load(object sender, EventArgs e)
        {
            this.DataBind();
        }
        public int Get_Count()
       {
          {
              string stmt = "SELECT COUNT(*) FROM dbo.listing";
              int count = 0;
              using (SqlConnection thisConnection = new SqlConnection("Data Source=DATASOURCE"))
                {
                   using (SqlCommand cmdCount = new SqlCommand(stmt, thisConnection))
                     {
                        thisConnection.Open();
                        count = (int)cmdCount.ExecuteScalar();
                     }
               }
              return count;
           }
        }
