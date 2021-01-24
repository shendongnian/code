     public void Delete(int[] ids, bool flag = false)
            {
                using (var context = new MyEntities())
                {
                    var items = context.Ads.Where(x => ids.Any(a => x.Id == a));
                    var groups = items.GroupBy(a => a.Group).Select(a => a.Key);
    
                    if (!flag)
                    {
                        //flag=false --> delete items with Id in ids[]
                        context.Ads.RemoveRange(items);
                    }
                    else
                    {
                        //flag=true --> delete all items in selected groups
                        context.Ads.RemoveRange(context.Ads.Where(x => groups.Any(a => x.Group == a)));
                    }
                    context.SaveChanges();
                }
