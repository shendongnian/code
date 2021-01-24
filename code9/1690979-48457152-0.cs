    //Assuming you're using Ints as your ID here, just sub in whatever ID you're using
                public static List<Item> GetByIDs(List<Int32> ids)
               {
                   using(var dbContext = new YourDBContextHere())
                   {
                     return dbContext.Items.Where(x => ids.Contains(x.ItemId)).ToList();
                   }
               }
