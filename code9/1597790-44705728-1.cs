        protected void DetectAddedOrRemoveAndSetEntityState<T>(IQueryable<T> old, List<T> current, TIERDBContext context) where T : class, IHasIntID
        {
            List<T> OldList = old.ToList();
            List<T> Added = current.ExceptBy(OldList, x => x.Id).ToList();
            List<T> Deleted = OldList.ExceptBy(current, x => x.Id).ToList();
            Added.ForEach(x => context.Entry(x).State = EntityState.Added);
            Deleted.ForEach(x => context.Entry(x).State = EntityState.Deleted);
        }
