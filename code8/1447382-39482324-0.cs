    Dictionary<string, decimal> listCart = new Dictionary<string, decimal>();
    listCart.Add(item1, price1);
    listCart.Add(item2, price2);
    listCart.Add(item3, price3);
    listCart.Add(item4, price4);
    //or use a foreach loop to iterate through your items, assuming you initially have some sort of mapping between items and their prices
    
    
    lstCart.DataSource = new BindingSource(listCart, null); 
    lstCart.DisplayMember = "Key"; 
    lstCart.ValueMember = "Value";
