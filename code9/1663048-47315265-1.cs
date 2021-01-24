    public interface IStoreReader<T>
    {
        Task<IEnumerable<T>> Get(UserDb user);
    }
    
    public class ConversationReader : IStorReader<ConversationDb>
    {
        public async Task<IEnumerable<ConversationDb>> Get(UserDb user)
        {
            return await _convoRepo.Get(user.UserId); 
        }
    }
