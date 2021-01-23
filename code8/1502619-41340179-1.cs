      private bool update(List<Item> items, Item itemToUpdate)
      {
        lock (thisLock)
        {
          var lastItem = items.Single(w => w.IsActive == true);
          lastItem.IsActive = false;
          var newItem = new Item()
          {
             FirstName = string.IsNullOrEmpty(itemToUpdate.FirstName) ? lastItem.FirstName : itemToUpdate.FirstName,
            LastName = string.IsNullOrEmpty(itemToUpdate.LastName) ? lastItem.LastName : itemToUpdate.LastName,
            IsActive = true
          };
          items.Add(newItem);
        }
        return true;
      }
