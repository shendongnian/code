     public static T ExtractFrom<T>(T item, double amount)
        where T: Item
     {
         item.Quantity -= amount;
         return (T)Activator.CreateInstance(
             item.GetType(), new object[] { amount });
     }
