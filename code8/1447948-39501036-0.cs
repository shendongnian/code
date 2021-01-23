            var ctxEnteries = ctx.ChangeTracker.Entries();
            foreach (var entry in ctxEnteries)
            {
                //you can inspect the value like originalvalue, currentvalue, state, etc...
                var state = entry.State;
                var entity = entry.Entity;
            }
            
            ctx.SaveChanges();
