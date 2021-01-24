    public interface IStoreReader<T>
    {
        Task<IEnumerable<T>> Get<T>(UserDb user);
    }
    
    public class ConversationReader : IStorReader<ConversationDb>
    {
        public async Task<IEnumerable<ConversationDb>> Get(UserDb user)
        {
            return await _convoRepo.Get(user.UserId); // error here
        }
    }
