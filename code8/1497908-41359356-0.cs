    public class ClientResolver : IValueResolver<Source.Client, Target.ClientWeb, object>
    {
        public object Resolve(Source.Client source, Target.ClientWeb destination, object destMember, ResolutionContext context)
        {
            if (source is Source.NewClient)
            {
                return Mapper.Map<Source.NewClient, Target.NewClientWeb>(source as Source.NewClient);
            }
            else if (source is Source.ExistingClient)
            {
                return Mapper.Map<Source.ExistingClient, Target.ExistingClientWeb>(source as Source.ExistingClient);
            }
            return null;
        }
    }
