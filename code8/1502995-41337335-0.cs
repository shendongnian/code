      ItemData itemData = newItem.GetComponent<ItemData>();
      if (itemData != null)
      {
        itemData.price = lootableItems[i].price; //example
      }
    }
