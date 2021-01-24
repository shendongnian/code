    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string headers = "CustomerID" + Environment.NewLine
            + "Name" + Environment.NewLine
            + "Email";
        StringBuilder sb = new StringBuilder();
        List<CustomerInfo> customerList = GetCustomers();
        foreach (CustomerInfo objCustomer in customerList)
        {
            sb.AppendLine(headers);
            sb.AppendLine(objCustomer.CustomerID);
            sb.AppendLine(objCustomer.Name);
            sb.AppendLine(objCustomer.Email);
        }
        byte[] bytes = Encoding.ASCII.GetBytes(sb.ToString());
        if (bytes != null)
        {
            Response.Clear();
            Response.ContentType = "text/csv";
            Response.AddHeader("Content-Length", bytes.Length.ToString());
            Response.AddHeader("Content-disposition", "attachment; filename=\"sample.csv" + "\"");
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
    }
