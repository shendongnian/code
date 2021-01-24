       public IQueryable<TSqlView> ReadSqlView<TSqlView>() where TSqlView : ISqlViewItem, new()
        {
            try
            {
                return (IQueryable<TSqlView>)Db.Set( typeof(TSqlView));
            }
            catch (Exception)
            {
                throw new IRepositoryException();
            }
        }
