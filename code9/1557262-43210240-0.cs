    public interface IStudenScheduleService : IGenericRepository<StudentSchedule> {
    }
    public interface IGenericRepository<T> {
        Task<T> AddAsync(T value, CancellationToken cancellationToken = default(CancellationToken));
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
