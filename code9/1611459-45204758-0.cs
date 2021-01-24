    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IBPJNA2;Initial Catalog=GeometryFINAL;Integrated Security=True");
    SqlCommand cmd;
    SqlDataReader rdr;
    if (Session["sOrderNo"] != null)
    {
       int intOrderNo = 0;
       bool result = Int32.TryParse(Session["sOrderNo"], out intOrderNo );
       if (result)
       {
          String strSql = "SELECT iProductID FROM orderItemsTable WHERE iOrderNo = " + intOrderNo;
          cmd = new SqlCommand(strSql, con);  
       }
       else
       {
           //values are not convertable to integer....
       }
    }
    else
    {
       //your session variable doesn't exist....
    }        
    
