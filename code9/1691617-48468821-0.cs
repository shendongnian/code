    foreach (var n in newItemValues)
            {
                Item item = oldItems.FirstOrDefault(x => x.Id == n.Id);
                if (item != null)
                {
                    n.field1 = item.field1;
                    n.field2 = item.field2;
                }
            }
