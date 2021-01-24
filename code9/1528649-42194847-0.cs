    using System;
    using System.Linq;
    using System.Text;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
    class Program
    {
        public static void Main()
        {
            var bread = new Product() { ID = 0, Cost = 1.0m, Name = "bread" };
            var milk = new Product() { ID = 1, Cost = 1.1m, Name = "milk" };
            var item0 = new OrderItem() { ID = 0, Product = bread, Quantity = 2 };
            var item1 = new OrderItem() { ID = 1, Product = milk, Quantity = 3 };
            var order = new Order() { ID = 0, OrderItems = new List<OrderItem>() { item0, item1 } };
            string data = order.ToString();
            Order copy = Order.FromString(data);
        }
    }
    public class Order
    {
        public int ID { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append(ID);
            builder.Append(';');
            foreach (var item in OrderItems)
            {
                builder.Append(item.ToString());
                builder.Append(';');
            }
            return builder.ToString();
        }
        public static Order FromString(string str)
        {
            var values = str.Split(';').ToList();
            int id = int.Parse(values[0]);
            var items = new List<OrderItem>();
            for (int i = 1; i < values.Count-1; i++)
            {
                items.Add(OrderItem.FromString(values[i]));
            }
            return new Order() { ID = id, OrderItems = items };
        }
    }
    public class OrderItem
    {
        public int ID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append(ID);
            builder.Append(',');
            builder.Append(Product.ToString());
            builder.Append(',');
            builder.Append(Quantity);
            return builder.ToString();
        }
        public static OrderItem FromString(string str)
        {
            var values = str.Split(',');
            int id = int.Parse(values[0]);
            Product product = Product.FromStrings(values.Skip(1).ToList());
            int quantity = int.Parse(values[4]);
            return new OrderItem() { ID = id, Product = product, Quantity = quantity };
        }
    }
    public class Product
    {
        public int ID { get; set; }
        public decimal Cost { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return string.Format("{0},{1},{2}", ID, Cost, Name);
        }
        public static Product FromStrings(List<string> strings)
        {
            int id = int.Parse(strings[0]);
            decimal cost = decimal.Parse(strings[1]);
            string name = strings[2];
            return new Product() { ID = id, Cost = cost, Name = name };
        }
    }
}
