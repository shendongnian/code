    foreach(var item2 in NewList){
    {
        foreach(var item1 in Inventory)
        { 
             if(item1.CarID == item2.CarID) // true only if old vehicle exist
             {
                  // break from loop
                  break;
             }
             else{
                  //code add item2 to Inventory
                  db.inventory.add(item2);
                  db.SaveChanges();
             }
        }
    }
