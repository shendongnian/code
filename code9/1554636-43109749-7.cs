    XmlSerializer serializer = new XmlSerializer(typeof(GetOrdersResponse ));
    using (TextReader reader = new StringReader(xmlResult))
    {
        GetOrdersResponse result = (GetOrdersResponse) serializer.Deserialize(reader);
    }
    int id=result.OrderArray.Orders.First().OrderID; //this will return ID of first object in Orders list.
