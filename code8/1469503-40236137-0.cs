    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Groceries3
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] groceries = File.ReadAllLines("Groceries.txt");
                List<string> invoices = new List<string>();
    
                int counter = 0;
                foreach (var grocery2 in groceries)
                {
                    counter++;
                    var list = grocery2.Split(',');
                    if (list[0].Equals("fresh"))
                    {
                        FreshGrocery freshGrocery = new FreshGrocery();
                        freshGrocery.Name = list[1];
                        freshGrocery.Price = double.Parse(list[2]);
                        freshGrocery.Weight = double.Parse(list[3].Replace(";", ""));
    
                        invoices.Add(counter + "," + freshGrocery.Name + "," + freshGrocery.Price + "," + freshGrocery.Weight + "," + DateTime.Now.Date);
                    }
                    else if (list[0].Equals("regular"))
                    {
                        Grocery grocery = new Grocery();
                        grocery.Name = list[1];
                        grocery.Price = double.Parse(list[2]);
                        grocery.Quantity = int.Parse(list[3].Replace(";", ""));
    
                        double price = grocery.Calculate();
                        invoices.Add(counter + "," + grocery.Name + "," + price + "," + grocery.Quantity + "," + DateTime.Now.Date);
                    }
                }
    
                File.WriteAllLines("Invoice.txt", invoices.ToArray());
            }
    
            abstract class GroceryItem
            {
                private string name;
                private double price = 0;
    
                public string Name
                {
                    get
                    {
                        return name;
                    }
                    set
                    {
                        name = value;
                    }
                }
                public double Price
                {
                    get
                    {
                        return price;
                    }
                    set
                    {
                        price = value;
                    }
                }
                public abstract double Calculate();
            }
    
            class FreshGrocery : GroceryItem
            {
                private double weight = 0;
                public double Weight
                {
                    get
                    {
                        return weight;
                    }
                    set
                    {
                        weight = value;
                    }
                }
                public override double Calculate()
                {
                    return this.Price * this.weight;
                }
            }
    
            class Grocery : GroceryItem
            {
                private int quantity = 0;
                private double gst = 10;
    
                public int Quantity
                {
                    get
                    {
                        return quantity;
                    }
                    set
                    {
                        quantity = value;
                    }
                }
                public override double Calculate()
                {
                    double calculatedPrice = this.Price * this.Quantity;
                    if (calculatedPrice < 0)
                    {
                        calculatedPrice += calculatedPrice * (gst / 100);
                    }
                     return calculatedPrice;
                }
            }
            class ShoppingCart
            {
                private List<GroceryItem> orders;
    
                public List<GroceryItem> Orders
                {
                    get
                    {
                        return orders;
                    }
                    set
                    {
                        orders = value;
                    }
                }
                public double Calculate()
                {
                    double price = 0;
                    if (this.Orders != null)
                    {
                        foreach (GroceryItem order in this.Orders)
                        {
                            price += order.Calculate();
                        }
                    }
                    return price;
                }
            }
        }
    }
