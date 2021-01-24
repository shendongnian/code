    string Product1= rd43.GetString(0);
    if(rd43.IsDBNull(Product1))
    {
        Products.Add("0");
    }
    else
    {
        Products.Add(Product1);
    }
