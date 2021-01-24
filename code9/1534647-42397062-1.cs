    public class Invoice{
     public string InvoiceNumber{get;set;}
     public string GrandTotal{get;set;}
     public string Date{get;set;}
    }
        List<Invoice> invoicesList = new List<Invoice>();
        foreach (var invoice in theInvoices)
        {
            invoicesList.Add(new Invoice(){InvoiceNumber=invoice.InvoiceNumber,          
                  GrandTotal= invoice.GrandTotal, 
                 Date=FieldTranslation.ToShortDate(invoice.Date.ToString())});
        }
