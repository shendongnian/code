    public static T Split<T>(T item, double amount) where T: Item
    {
        item.Quantity -= amount;
        return Activator.CreateInstance(item.GetType(), new object[] { amount }) as T;
    }
