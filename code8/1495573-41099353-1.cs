    foreach (Item item in purchasedItems)
            {
                if (item.Product != null)
                {
                    factor.Items.Add(item);
                    item.Product = null;//Setting Product to null
                }
            }
