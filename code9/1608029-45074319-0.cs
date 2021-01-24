    public interface ISingletonDependency { }
    public interface ITransientDependency { }
    public interface IPersonRepository : ISingletonDependency { }
    public class PersonRepository : IPersonRepository { }
    public interface IPersonService : ITransientDependency { }
    public class PersonService : IPersonService { }
