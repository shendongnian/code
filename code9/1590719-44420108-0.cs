     using (var context = new Db())
            {
                try
                {
                   ...
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    
                }
            }
