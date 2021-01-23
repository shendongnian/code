    public class CSVFormatterLibrary
    {
         public ICSVFormatter GetFormatter(IDocument document)
         {
           //we've added DocType to IDocument to identify the document type.
            if(document.DocType==DocumentTypes.Invoice)
            {
                 return new InvoiceCSVFormatter(document);
            }
            if (document.DocType==DocumentTypes.SalesOrders)
            {
                return new SalesOrderCSVFormatter(document);
            }
            //And so on
         }
    }
