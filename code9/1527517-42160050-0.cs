    public async Task SaveShoppingObjects(List<ShoppingObjects> shoppingsObjects)
    {
        await database.RunInTransactionAsync(tran =>
        {
            foreach (ShoppingObject s in shoppingObjects)
            {
                tran.InsertOrReplace(SqliteEntityFactory.Create(s));
            }
        });
    }
