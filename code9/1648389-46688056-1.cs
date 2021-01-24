     public void Delete(int[] ids, bool flag = false)
            {
                using (var context = new MyEntities())
                {
                    var items = context.Ads.Where(x => ids.Any(a => x.Id == a));
                   
    
                    if (!flag)
                    {
                        //flag=false --> delete items with Id in ids[]
                        context.Ads.RemoveRange(items);
                    }
                    else
                    {
                        var groups = items.GroupBy(a => a.Group).Select(a => a.Key);
                        //flag=true --> delete all items in selected groups
                        context.Ads.RemoveRange(context.Ads.Where(x => groups.Any(a => x.Group == a)));
                    }
                    context.SaveChanges();
                }
