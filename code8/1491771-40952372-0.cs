    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class MainClass {
      public static void Main (string[] args) {
        var items = new List<CartItem>();
        items.Add(new CartItem("product1"));
        items.Add(new CartItem("product2"));
        items.Add(new CartItem("product3"));
        
        var product = items.Select(_ => _.Text).Aggregate((p1, p2) => p1+"."+p2);
        
        Console.WriteLine(product);
      }
    }
    
    class CartItem {
      internal CartItem(string text) {
        Text = text;
      }
      public string Text {get;}
    }
