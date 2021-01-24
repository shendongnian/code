        Parallel.ForEach(filteredList, (f) =>
        {
            var conditionMatchCount = itm.AsParallel().Max(i =>
            // One point if ID matches
            ((i.ItemID == f.ItemID) ? 1 : 0) +
            // One point if ID and QuantitySold match
            ((i.ItemID == f.ItemID && i.QuantitySold == f.QuantitySold) ? 1 : 0)
            );
            // Item is missing
            if (conditionMatchCount == 0)
            {
                listToUpdate.Add(f);
                missingList.Add(f);
            }
            // Item quantity is different
            else if (conditionMatchCount == 1)
            {
                listToUpdate.Add(f);
            }
        });
