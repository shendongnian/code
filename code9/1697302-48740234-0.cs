    public ActionResult Index(string ColumnName, string SearchText)
    {
        var arg = Expression.Parameter(typeof(Customer), "x");
    
        var strType = typeof(string);
        var ToUpperMeth = strType.GetMethods().Where(x => x.Name == nameof(string.ToUpper) 
                                              && x.GetParameters().Count() == 0).Single();
        var ContainsMeth = strType.GetMethods().Where(x => x.Name == nameof(string.Contains) 
                                              && x.GetParameters().Count() == 1).Single();
    
        var exprVal = Expression.Constant(SearchText);
        var toUpExprVal = Expression.Call(exprVal, ToUpperMeth);
        var exprProp = Expression.Property(arg, ColumnName);
        var toUpExpr = Expression.Call(exprProp, ToUpperMeth);
        var contExpr = Expression.Call(toUpExpr, ContainsMeth, toUpExprVal);
        var predicate = Expression.Lambda<Func<Customer, bool>>(contExpr, arg);
        var customer = (from s in db.Customers
                        select new CustomerDTO
                        {
                            CustomerID = s.CustomerID,
                            CompanyName = s.CompanyName,
                            ContactName = s.ContactName,
                            ContactTitle = s.ContactTitle,
                            Address = s.Address
                        }).Where(predicate).ToList();
        return View(customer);
    }
