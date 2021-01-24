    foreach(var item1 in Inventory)
    {
        foreach(var item2 in NewList){
        { 
             if(item1.CarID == item2.CarID) // true only if old vehicle exist
             {
                  // break from loop
                  break;
             }
             else{
                  // remove item1 from Inventory
                  db.inventory.remove(item1);
                  db.SaveChanges();
             }
        }
    }
