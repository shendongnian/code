    public Item Split(double amount)
    {
        Quantity -= amount;
        return Activator.CreateInstance(GetType(), new object[] { amount }) as Item;
    }
