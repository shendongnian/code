     protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string headers = "CustomerID" + Environment.NewLine
                              + "Name" + Environment.NewLine
                              + "Email" + Environment.NewLine;
            StringBuilder sb = new StringBuilder();
            //sb = sb.Append(string.Format("{0},{1},{2}", "CustomerID", "Name", "Email") + Environment.NewLine);
    
            List<CustomerInfo> customerList = GetCustomers();
            foreach (CustomerInfo objCustomer in customerList)
            {
                //sb.Append(string.Format("{0},{1},{2}", objCustomer.CustomerID.ToString(), objCustomer.Name, objCustomer.Email) + Environment.NewLine);
    
                sb.Append(headers);
                sb.Append(objCustomer.CustomerID.ToString());
                sb.Append(Environment.NewLine);
                sb.Append(objCustomer.Name);
                sb.Append(Environment.NewLine);
                sb.Append(objCustomer.Email);
                sb.Append(Environment.NewLine);
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
