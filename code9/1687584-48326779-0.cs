    public void AddMyItem(Item item)
    {
        using (var context = new MyContext())
        {
    		context.Items.Add(item);
            context.SaveChanges();
        }
    }
