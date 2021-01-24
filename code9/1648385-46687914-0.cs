        public static void Delete(int[] ids, bool flag = false)
        {
            using (var context = new MyEntities())
            {
                var query = context.Ads.AsQueryable();
                query = flag
                  ? query.Where(x => context.Ads
                                       .Where(i => ids.Contains(i.Id))
                                       .Select(i => i.Group)
                                       .Contains(x.Group))
                  : query.Where(x => ids.Contains(x.Id));
                context.Ads.RemoveRange(query);
                context.SaveChanges();
            }
        }
