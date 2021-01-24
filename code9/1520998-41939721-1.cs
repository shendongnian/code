    protected void filterbutton_Click(object sender, EventArgs e)
    {   
            string stroStatus = "";
            string stroDelivery_Status = "";
            SqlDataSource1.SelectParameters["oStatus"].DefaultValue = stroStatus;
            Parameter pm = SqlDataSource1.SelectParameters["oDelivery_Status"];
            if (!SqlDataSource1.SelectParameters.Contains(pm))
            {
               SqlDataSource1.SelectParameters.Add("oDelivery_Status",   
               stroDelivery_Status);
            }
           SqlDataSource1.SelectCommand = "SELECT * FROM [Orders] WHERE ([oStatus] = @oStatus) AND ([oDelivery_Status] = @oDelivery_Status)"
    }
