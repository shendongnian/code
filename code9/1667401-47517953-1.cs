            using (var scope = new TransactionScope())
            {
                //Some EF Statments
                Context.SaveChanges();
                scope.Complete();
            }
