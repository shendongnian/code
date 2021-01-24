    public class MoreSpecificThingFactory : AbstractThingFactory<SpecificFactoryRequest>
    {
        protected override IThingFactory<SpecificFactoryRequest> GetInnerFactory(SpecificFactoryRequestrequest)
        {
            if (request is MoreSpecificFactoryRequest)
            {
                // return an even more specific factory...
            }
            // throw an exception or do something else
        }
    }
