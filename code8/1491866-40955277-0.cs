    public async Task Save(){    
        var result = await context.Batch.Where(i => i.Item_No == "235").FirstOrDefaultAsync();
        if(result != null)
        {
            result.ItemQty = 10;
            await context.SaveChangesAsync();
        }
    }
