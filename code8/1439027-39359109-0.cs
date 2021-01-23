    public class PaymentItemMapping : ClassMapping<PaymentItem> {
        
        public PaymentItemMapping() {
            Table("PaymentItems");
            Lazy(true);
            Id(x => x.ID, map => map.Generator(Generators.Identity));
            ManyToOne(x => x.OwningBillingItem, m => {
                //Do not map to m.Column("ID");
                m.Column("BillingItemID");
                // BillingItemID can be insert and update
                m.Update(true);
                m.Insert(true);
                m.Cascade(Cascade.None);
                m.Fetch(FetchKind.Join);
                m.NotFound(NotFoundMode.Exception);
                m.Lazy(LazyRelation.Proxy);
                m.ForeignKey("BillingItemID");
            });
            Property(x => x.DueDate, map => map.NotNullable(true));
            // ... other properties.
        }
    }
