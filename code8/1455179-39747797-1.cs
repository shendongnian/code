        [Service]
    public partial class BankBusiness : Service<Bank>, IBankBusiness
    {
        public BankBusiness()
            : base(ContainerManager.Container.Resolve<MyContext>())
        {
            base.PopulateEvents(this);
        }
        public override void OnBeforeSavingRecord(object sender, EntitySavingEventArgs<Bank> e)
        {
            base.OnBeforeSavingRecord(sender, e);
        }
    }
