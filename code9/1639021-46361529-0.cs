     string ord = "";
            string pn = "";
            string des = "";
            string cpn = "";
            string rev = "";
            string esd = "";
            string qty = "";
            string eml = "";
            string sbj = "";
            string str = @"Data Source=my data source;Initial Catalog=my table;Integrated Security=True";
            SqlConnection scn;
            SqlDataAdapter da;
            DataSet ds;
            salesOrdersTableAdapter.SO(_TST_TWIDataSet.SalesOrders);
            scn = new SqlConnection(str);
            da = new SqlDataAdapter("SELECT DISTINCT DATEADD (dd, DATEDIFF(dd,0,ShipDate),0) AS ShipDate,RTRIM(SalesOrder) AS [Sales Order], RTRIM(PartNum) AS [Part Number]," +
                "RTRIM(Description) AS Description,RTRIM(DueQty) AS Quantity,RTRIM(CustPartNum) AS[Customer Part No], RTRIM(CustPo) AS[Customer PO], " +
                                     "RTRIM(CustRev) AS[Customer Rev], RTRIM(email) AS [Email] " +
                                     "FROM SalesOrders WHERE Ack <> 'Y'AND SalesOrder =" + MyGlobals.ord, scn);
            ds = new DataSet();da.Fill(ds, "SalesOrders");
            foreach(DataRow Row in ds.Tables["SalesOrders"].Rows)
            {
                ord = ord + " Order Number "+ Row["Sales Order"];
                pn = pn + " Part Number: " + Row["Part Number"];
                des = des + "Description: " + Row["Description"];
                cpn = cpn + "Customer Part Number: " + Row["Customer Part No"];
                rev = rev + "Customer Revision: " + Row["Customer Rev"];
                DateTime dte = DateTime.Now;               
                esd = esd + "Expected Ship Date: " + dte.ToShortDateString();
                qty = qty + "Quantity: " + Row["Quantity"];
                eml = eml +  Row["Email"];
                sbj = sbj + "Order Acknowledgement for your PO " + Row["Customer PO"];
            }
