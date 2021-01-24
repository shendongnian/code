    MyCollection = MyCollection.Select(data =>
    {
        if (data.DeliveryDate.Equals("Tomorrow"))
            data.DeliveryDate = MyMethodToConvert(DeliveryDate);
        return data;
    }).ToList();
