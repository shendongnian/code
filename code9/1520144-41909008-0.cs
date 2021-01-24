    static IEnumerable<Order> LoadOrders()
    {
        using (IDataReader reader = OrderCollection.PageDataLoadAll(null))
        {
            while (reader.Read())
            {
                Order o = new Order();
                o.RaisePropertyChangedEvents = false;
                ((ICodeFluentEntity)o).ReadRecord(reader);
                yield return o;
            }
            CodeFluentPersistence.CompleteCommand(Constants.NorthwindStoreName);
        }
    }
