    protected void ddlAirport00_SelectedIndexChanged(object sender, EventArgs e)
    {
       String CS = CnfigurationManager.ConnectionStrings
           ["MyDatabaseConnectionString1"].ConnectionString;
       using (SqlConnection scon = new SqlConnection(CS))
       {
          sda = new SqlDataAdapter("Select * from Tramo", scon);
          sda.Fill(ds, "Tramo");
          // Do something.
          if (ds.Tables.Contains("Tramo"))
          {
              testeeric.Text = DateTime.Now.ToString();
          }
          else
          {
              testeeric.Text = "Brasil";
          }
       }
    }
