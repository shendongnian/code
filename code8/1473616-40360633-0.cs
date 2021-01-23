    model.Item = await db.Items.FindAsync(id);
    if (model.Item == null)
    {
        return HttpNotFound();
    }
    await db.Entry(model.Item).Collection(i => i.ItemVerifications).LoadAsync();    
