    public class ValidatorName : IValidator
    {
        public void Process()
        {
            INameDB db = AutofacHostFactory.Container.Resolve<INameDB>();
            db.AnyThing(pedidoId);
        }
    }
    public class ValidatorName2 : IValidator
    {
        public void Process()
        {
            INameDB2 db = AutofacHostFactory.Container.Resolve<INameDB2>();
            db.AnyThing2(pedidoId);
        }
    }
    public class ValidatorName3 : IValidator
    {
        public void Process()
        {
            INameDB2 db = AutofacHostFactory.Container.Resolve<INameDB2>();
            db.AnyThing2(pedidoId);
        }
    }
