    public class NeedsToReadFromRepository<Thing>
    {
        private readonly IReadableRepository<Thing, Guid> _repository;
        public NeedsToReadFromRepository(IReadableRepository<Thing, Guid> repository)
        {
            _repository = repository;
        }
    }
