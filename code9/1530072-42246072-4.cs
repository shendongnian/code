    public static void Serialize(IEnumerable<InvoicePair> invoices, Stream stream)
    {
        Root root = new Root();
        foreach (var invoice in invoices)
        {
            root.RootBodies.Add(invoice.EInvoiceInfo);
            root.RootBodies.Add(invoice.TradeInvoice);
        }
        XmlSerializer serializer = new XmlSerializer(typeof(Root));
        serializer.Serialize(stream, root);
    }
