    try
    {
      SqlCommand cmd = new SqlCommand("ProcedureBindAllProducts",con);
      DataTable dt = new DataTable();
      dt.Load(cmd.ExecuteReader());
      rptrProducts.DataSource= dtBrands;
      rptrProducts.DataBind();
    }
    catch(Exception Ex)
    {
      Console.WriteLine(Ex.Message.ToString());
    }
