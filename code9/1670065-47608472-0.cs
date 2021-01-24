    public static class UserEntityExtensions
    {
        public static void ConvertRelatedEntities(this User userTwo, User userOne)
        {
            userTwo.PostsCreatedByUser.ToList().ForEach(a => a.CreatedByUserId = userOne.Id);
            userTwo.NotesCreatedByUser.ToList().ForEach(a => a.CreatedByUserId = userOne.Id);
        }
    }
