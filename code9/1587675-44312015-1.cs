    using (AppContext ctx = new AppContext()) {
        return ctx.Customers.
            Include(x => x.WarehouseNotes.Select(y => y.Wharehouse)).
            Where(x => x.ID == oneID).
            ToList();
    }
