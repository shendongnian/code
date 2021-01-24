	public IList<UniStock.Domain.Tables.Inventory> SelectInventoryListByColourSizeGroup(string styleColour, string sizeGroup)
    {
        var db = new UniStockContext();
        IQueryable<Domain.Tables.Inventory> q = (from c in db.Inventories
                   join o in db.SizeGroupSizes
                   on c.Size.Trim() equals o.Description.Trim()
                   where (c.SytleColour == styleColour)
                   && (o.SizeGroup.Description == sizeGroup)
                   select c);
        return list;
    }
