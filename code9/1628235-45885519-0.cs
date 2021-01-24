    public void Get_Billing_Type()
    {
    	try
    	{
    		DataTable dt = new DAL_Set_Billing_Type().Get_Billing_Type();
    		foreach (DataRow row in dt.Rows)
                    {
                        switch(row[0].ToString())
                        {
                            case "1":
                                {
                                    row["type_id"] = "silk";
                                    break;
                                }
                            case "2":
                                {
                                    row["type_id"] = "siffon";
                                    break;
                                }
                            case "3":
                                {
                                    row["type_id"] = "cotton";
                                    break;
                                }
                        }
                    }
    		GridView1.DataSource = dt;
    		GridView1.DataBind();
    	}
    	catch (Exception) {  }
    }
