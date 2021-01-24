    var productsLocation = new List<int>() { 0,1,2,3}; //It's for example, we dont know your responce var type
    IEnumerable<int> item;  //IEnumerable<T> : T should be same as productsLocation item type
    if (condition)
    {
    	item = productsLocation.Where(condition);
    }
    else
    {
    	item = productsLocation.Where(condition);
    }
    var group = item.Where(condition);
