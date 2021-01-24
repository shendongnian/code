    using (var context = new TestEntities())
    {
    	if (!flag)
    		context.Ads.RemoveRange(context.Ads.Where(a => ids.Contains(a.Id)));
    	else
    		context.Ads.RemoveRange(context.Ads.Where(a => context.Ads.Where(g => ids.Contains(g.Id)).Select(x => x.Group).Distinct().Contains(a.Group)));
    	context.SaveChanges();
    }
