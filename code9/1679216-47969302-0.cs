    public abstract class Item<T> where T : Item<T>, new() {
      public double Quantity { get; private set; }
      public static T Create(double quantity) {
        return new T { Quantity = quantity };
      }
      public void Merge(T item) {
        Quantity += item.Quantity;
      }
      public T Split(double amount) {
        Quantity -= amount;
        return Create(amount);
      }
    }
