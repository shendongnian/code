    public static IEnumerable<InvoicePair> Deserialize(Stream stream)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Root));
        Root root = serializer.Deserialize(stream) as Root;
        for (int i = 0; i < root.RootBodies.Count; i += 2)
        {
            yield return new InvoicePair((EInvoice) root.RootBodies[i], (TradeInvoice) root.RootBodies[i+1]);
        }
    }
