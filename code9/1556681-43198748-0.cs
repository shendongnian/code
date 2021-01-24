    public class UniqueRequestId 
    {
        public readonly Guid Id = Guid.NewGuid();
    }
    Bind<UniqueRequestId>().ToSelf()
        .InRequestScope();
