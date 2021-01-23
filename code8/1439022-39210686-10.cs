    ManyToOne(x => x.OwningBillingItem, m =>
    {
        m.Column("ID");
        // this is stopper - DO NOT use it
        //m.Update(false);
        //m.Insert(false);
