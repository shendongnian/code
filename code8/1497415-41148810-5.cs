       public override void Insert(Item entity)
        {
            base.Insert(entity);
            new GenericHistoryRepository<Item_History>().Add(entity);
        }
        ...
    
        new GenericHistoryRepository<XXX_History>().Add(entity);
