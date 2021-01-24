            static void Main(string[] args)
            {
                string sConnectionString;
                sConnectionString = "Data Source=NAMESERWER;Initial Catalog=BAZA;Persist Security Info=True;User ID=user; Password=password;";
                SqlConnection objConn = new SqlConnection(sConnectionString);
                objConn.Open();
                SqlDataAdapter faktura = new SqlDataAdapter("SELECT  [t0].[Faktura] as 'InvoiceNumber', [t0].[FATrN_Data2] as 'Date', [t0].[FATrN_Data3] as 'InvoiceIssueDate',  DATEADD(DD, 90, [t0].[FATrN_Data3]) as 'InvoiceDueDate', '90' as 'PaymentTerms', 'I' as 'PaymentTermsReferenceDate' FROM [CDN].[INEcodFANaglo] AS [t0] WHERE ([t0].[TrN_GIDNumer] = '1015871') AND ([t0].[TrN_GIDTyp] = '2033')", objConn);
                SqlDataAdapter paymentmethod1 = new SqlDataAdapter("SELECT  'P' as 'CODE', 'Przelew' as 'Description' FROM [CDN].[INEcodFANaglo] AS [t0] WHERE ([t0].[TrN_GIDNumer] = '1015871') AND ([t0].[TrN_GIDTyp] = '2033')", objConn);
                DataSet ds = new DataSet("Invoice");
                faktura.Fill(ds, "InvoiceHeader");
                MemoryStream stream = new MemoryStream();
                ds.WriteXml(stream);
                stream.Position = 0;
                XDocument doc = XDocument.Load(stream);
                XElement invoice = doc.Element("Invoice");
                DataTable dt = new DataTable("PaymentMethod");
                paymentmethod1.Fill(dt);
                stream = new MemoryStream();
                dt.WriteXml(stream);
                stream.Position = 0;
                XElement paymentMethod = XElement.Load(stream);
                invoice.Add(paymentMethod);
            }
