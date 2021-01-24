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
    		Supply supply3 = new Supply() { ID = 3, SupplierName = "Supplier Three"};
    		
    		lstSuppliers.Add(supply1);
    		lstSuppliers.Add(supply2);
    		lstSuppliers.Add(supply3);
    		
    		Product product1 = new Product() {ID = 1, UnitsInStock = 3, SupplierID = 1};
    		Product product2 = new Product() {ID = 2, UnitsInStock = 3, SupplierID = 2};
    		Product product3 = new Product() {ID = 3, UnitsInStock = 5, SupplierID = 1};
    		Product product4 = new Product() {ID = 4, UnitsInStock = 8, SupplierID = 3};
    		
    		List<Product> lstAllProducts = new List<Product>();
    		lstAllProducts.Add(product1);
    		lstAllProducts.Add(product2);
    		lstAllProducts.Add(product3);
    		lstAllProducts.Add(product4);
    		
    		// finds largest supplier
    		//var findSupplierId = lstAllProducts.GroupBy(x => x.SupplierID).Select(x => new{ Supplier = x.Key.ToString(), Count = x.Sum(g => g.UnitsInStock)}).OrderByDescending(x => x.Count).First().Supplier;
    		//Console.WriteLine(lstSuppliers.Single(x => x.ID.ToString() == findSupplierId).SupplierName);
    		
    		// What if there are multiple suppliers with the same number of units in stock?
    		
    		// first - we have to find the largest number of units in stock
    		var findLargestNumberUIS = lstAllProducts.GroupBy(x => x.SupplierID).Select(x => new{ Supplier = x.Key.ToString(), Count = x.Sum(g => g.UnitsInStock)}).Max(x => x.Count); // 8
    		
    		// second - gather a list of suppliers where their units in stock == findLargestNumberUIS
    		var lstOfLargestSuppliers = lstAllProducts.GroupBy(x => x.SupplierID).Select(x => new{ Supplier = x.Key.ToString(), Count = x.Sum(g => g.UnitsInStock)}).Where(x => x.Count == findLargestNumberUIS).ToList();
    		
    		// third - loop through lstOfLargestSuppliers to get all suppliers that have the same amount of units in stock which happen to be the largest
    		foreach(var item in lstOfLargestSuppliers){
    			var supplier = lstSuppliers.Single(x => x.ID.ToString() == item.Supplier).SupplierName;
    			Console.WriteLine(supplier); // print the supplier names to console
                // Output - Supplier One
                //          Supplier Three
    		}
    		
    		
    		
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
