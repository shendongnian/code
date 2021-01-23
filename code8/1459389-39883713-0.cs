    public class ModelFactory
    {
        public Expression<Func<Comment, ApplicationUser, CommentWithUserDetails>> Create()
        {
            return (comment, user) => new CommentWithUserDetails
            {
                Id = comment.Id,
                PostId = comment.PostId,
                Body = comment.Body,
                Name = user.Name
            };
        }
    }
