     public async Task<IEnumerable<Component>> 
         GetComponentsByEquipmentIdAsync(int equipmentId)
    {
        using (var dbContext = new MyDbContext())
        {
            var result = ... // see above
            return await result.ToListAsync();
        }
     }
