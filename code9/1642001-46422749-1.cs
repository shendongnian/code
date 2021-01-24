        private Entities AddToContext(Entities context, T entity, int count, int commitCount, bool recreateContext)
        {
            context.Set<T>().Add(entity);
            if (count % commitCount == 0)
            {
                context.SaveChanges();
                if (recreateContext)
                {
                    context.Dispose();
                    context = new Entities();
                    context.Configuration.AutoDetectChangesEnabled = false;
                }
            }
            return context;
        }
