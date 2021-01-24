    // Start finding the base item to start the recursive search
    Item x = items.Where(i => i.Id == 9).FirstOrDefault();
    List<Item> found = Search(items, x);
    // Insert the starting item at the first position (Add is also good but...)
    found.Insert(0, x);
   
    public List<Item> Search(List<Item> list, Item parent)
    {
        // Prepare the list to return...
        List<Item> found = new List<Item>();
        if (parent != null)
        {
            // Search all the items that have the parent passed
            List<Item> temp = list.Where(x => x.ParentId == parent.Id).ToList();
            // Add the list to the return variable
            found.AddRange(temp);
            // For each child of this parent look for their childs
            foreach(Item x in temp)
                found.AddRange(Search(list, x));
        }
        return found;
    }
