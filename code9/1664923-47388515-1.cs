    if(ds.Tables[0].Rows[0]["PretrailOrderDate"] == DBNull.Value)
    {
        //Action to take if null value
    }
    else
    {
        try
        {
            lbltrialval.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]
            .Field<DateTime>("PretrailOrderDate")).ToString("MM/dd/yyyy");
        }
        catch(Exception e)
        {
            //Conversion Error
            Console.WriteLine(e.Message);
        }
    }
