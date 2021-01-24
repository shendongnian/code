    private void button5_Click(object sender, EventArgs e)
            {
           
                string sConnectionString;
                sConnectionString = "Data Source=SERWER;Initial Catalog=baza;Persist Security Info=True;User ID=user; Password=pass;";
                SqlConnection objConn = new SqlConnection(sConnectionString);
                objConn.Open();
                SqlDataAdapter faktura = new SqlDataAdapter("SELECT  [t0].[Faktura] as 'InvoiceNumber', [t0].[FATrN_Data2] as 'Date', [t0].[FATrN_Data3] as 'InvoiceIssueDate',  DATEADD(DD, 90, [t0].[FATrN_Data3]) as 'InvoiceDueDate', '90' as 'PaymentTerms', 'I' as 'PaymentTermsReferenceDate' FROM [CDN].[INEcodFANaglo] AS [t0] WHERE ([t0].[TrN_GIDNumer] = '1015871') AND ([t0].[TrN_GIDTyp] = '2033')", objConn);
                SqlDataAdapter paymentmethod1 = new SqlDataAdapter("SELECT  'P' as 'CODE', 'Przelew' as 'Description' FROM [CDN].[INEcodFANaglo] AS [t0] WHERE ([t0].[TrN_GIDNumer] = '1015871') AND ([t0].[TrN_GIDTyp] = '2033')", objConn);
                DataSet ds = new DataSet("Invoice");
                faktura.Fill(ds, "InvoiceHeader");
                MemoryStream stream = new MemoryStream();
                ds.WriteXml(@"c:\test1.xml");
                stream.Position = 0;
                XDocument doc = XDocument.Load(@"c:\test1.xml");
                XElement invoice = doc.Element("Invoice");
                DataTable dt = new DataTable("PaymentMethod");
                paymentmethod1.Fill(dt);
                stream = new MemoryStream();
                dt.WriteXml(@"c:\test1.xml");
                stream.Position = 0;
                XElement paymentMethod = XElement.Load(@"c:\test1.xml");
                invoice.Add(paymentMethod);
            }
        }
    }
