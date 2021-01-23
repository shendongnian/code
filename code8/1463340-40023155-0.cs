    public class MessageScript : BaseScript<Message>
    {
        public IEnumerable<Message> GetAllByLanguagePublic(string language)
        {
            return this.GetAll()
                .Include(x => x.User)
                .Include(x => x.MessageViews)
                .Where(x => x.Language == language).ToList();
        }
    }
