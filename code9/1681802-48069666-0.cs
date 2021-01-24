    public class GetReminder : IQuery
    {
        public async Task<T> Result<T>() where T: ReminderDb, new()
        {
            return await Task.FromResult(new T()); // return a new instance
        }
    }
