     // product
     Product prod = new Product(); 
     prod.Name = "Q3"; prod.Category = "Audi"; 
     prod.Discontinued = false; 
     // product type
     ProductType productType = new ProudctType();
     ...
 
     // both sides assigned
     prod.ProductTypes.Add(productType);
     productType.Product = prod;
     session.Save(prod);  
