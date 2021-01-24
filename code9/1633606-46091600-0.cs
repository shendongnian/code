    using (var ctx = new MyCOntext())
    {
         var allToBeUpdated = await ctx.Items.Where(t=>t.ToBeUpdated == true).ToListAsync();
    
          foreach (var item in allToBeUpdated)
          {
                item.ToBeUpdated = false; //change tracking will take care of tracking what is changed
          }
    
           await ctx.SaveChangesAsync();  // Save changes outside will update all the pending changes 
    }
