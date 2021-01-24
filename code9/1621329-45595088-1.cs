    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		List<Supply> lstSuppliers = new List<Supply>();
    		Supply supply1 = new Supply() { ID = 1, SupplierName = "Supplier One"};
    		Supply supply2 = new Supply() { ID = 2, SupplierName = "Supplier Two"};
    		
    		lstSuppliers.Add(supply1);
    		lstSuppliers.Add(supply2);
    		
    		Product product1 = new Product() {ID = 1, UnitsInStock = 3, SupplierID = 1};
    		Product product2 = new Product() {ID = 2, UnitsInStock = 3, SupplierID = 2};
    		Product product3 = new Product() {ID = 3, UnitsInStock = 5, SupplierID = 1};
    		
    		List<Product> lstAllProducts = new List<Product>();
    		lstAllProducts.Add(product1);
    		lstAllProducts.Add(product2);
    		lstAllProducts.Add(product3);
    		
    		var findSupplierId = lstAllProducts.GroupBy(x => x.SupplierID).Select(x => new{ Supplier = x.Key.ToString(), Count = x.Sum(g => g.UnitsInStock)}).OrderByDescending(x => x.Count).First().Supplier;
    		
    		Console.WriteLine(findSupplierId);
    		
    		
    		
    		Console.WriteLine(lstSuppliers.Single(x => x.ID.ToString() == findSupplierId).SupplierName);
    		
    	}
    }
    
    public class Supply{
    	public int ID {get;set;}
    	public string SupplierName {get;set;}
    }
    
    public class Product{
    	public int ID {get;set;}
    	public int UnitsInStock {get;set;}
    	public int SupplierID {get;set;}
    }
