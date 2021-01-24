    public List<Item> GetItems(HttpContext httpContext)
        {
         List<Item> Items = new List<Item>();  
            var session = httpContext.Session.GetInt32("Session");
           
         return Items
        }
