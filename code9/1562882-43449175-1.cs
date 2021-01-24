      public void Approved(List<int> list,int stat )
            {
                
              
                var friends = context.Requery.Where(f => list.Contains(f.parametr)).ToList();
       
                friends.ForEach(a =>
                {
                    a.par1 = 0;
                    a.par2 = stat;
                });
                
             
                context.SaveChanges();
              
            }
