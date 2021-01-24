    Item x = items.Where(i => i.Id == 9).FirstOrDefault();
    List<Item> found = Search(items, x);
    found.Insert(0, x);
   
    public List<Item> Search(List<Item> list, Item parent)
    {
        List<Item> found = new List<Item>();
        if (parent != null)
        {
            List<Item> temp = list.Where(x => x.ParentId == parent.Id).ToList();
            found.AddRange(temp);
            foreach(Item x in temp)
                found.AddRange(Search(list, x));
        }
        return found;
    }
