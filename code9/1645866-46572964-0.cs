     object myObject = db.MinimumProductInfo.FirstOrDefault(pc => pc.ItemCode == 
            productInfoWithNote.ItemCode && pc.Region == productInfoWithNote.Region);
        
        if(myObject != null)
        {
             // use your object here
        } 
