    public void  AddToCart(int id,int count)
    {            
        productInvertoryTable t = db.productInvertoryTables.SingleOrDefault(x => x.Id == id);
        cartTable ct = new cartTable();
    
        if (db.cartTables.SingleOrDefault(q => q.prod_Id == t.Id) == null)
        {
            ct.datee = DateTime.Today.ToString();
            ct.prod_Id = t.Id;
            ct.name = t.name;
            ct.quantity = count;
            ct.pricee = t.sellprice * count;
            db.cartTables.InsertOnSubmit(ct);
            t.quantity -= count;
            db.SubmitChanges();
        }
        else
        {
            cartTable cct = db.cartTables.SingleOrDefault(q => q.prod_Id == t.Id);
            cct.quantity += count;
            t.quantity -= count;
            cct.pricee += (count * t.sellprice);
            cct.datee = DateTime.Today.ToString();
            db.SubmitChanges();
        }
        showdetails(); //Move outside to refresh the grid after save/update
    }
