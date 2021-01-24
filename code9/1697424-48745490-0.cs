    private void CreateXMLHeader()
        {
            var oAgresso = new ABWInvoice { };
            List<ABWInvoiceInvoice> invlist = new List<ABWInvoiceInvoice>();
            invlist.Add(new ABWInvoiceInvoice { InvoiceNo = "1" ,
            Header= new ABWInvoiceInvoiceHeader()
            {
                OrderRef = "5678",
                InvoiceDate = DateTime.Now
            }
            });
            oAgresso.Invoice = invlist.ToArray();
