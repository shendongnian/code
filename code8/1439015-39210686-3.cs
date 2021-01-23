    Set(x => x.PaymentItems, c =>
    {
        c.Key(k =>
        {
            k.Column("BillingItemID");
        });
        c.Inverse(true);
        //c.Cascade(Cascade.None);
        c.Cascade(Cascade.All);
    },
