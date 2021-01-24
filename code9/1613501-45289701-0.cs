    public class PersonRepository : BaseRepository<Person>, IPersonRepository {
        public PersonRepository(IUnitOfWork unitOfWork) : base(unitOfWork) {
            //...
        }
    }
