    public class Invoice{
     public string InvoiceNumber{get;set;}
     public string GrandTotal{get;set;}
     public string Date{get;set;}
    }
        List<string> invoicesList = new List<string>();
        foreach (var invoice in theInvoices)
        {
            invoicesList.Add(new Invoice(){InvoiceNumber=invoice.InvoiceNumber,          
                  GrandTotal= invoice.GrandTotal, 
                 Date=FieldTranslation.ToShortDate(invoice.Date.ToString())});
        }
