    select new  MVCApp.Models.Products_Categories_SuppliersModel
    {  
    ProductName = p.ProductName,
    CategoryName = c.CategoryName,
    Description = c.Description,
    ContactName = s.ContactName,
    ContactTitle = s.ContactTitle,
    CompanyName = s.CompanyName,
    Phone = s.Phone,
    City = s.City,
    Country = s.Country };
