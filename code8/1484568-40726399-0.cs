    public class Post
    {
        public int Id { get; set; }
        public ICollection<Comment> Comments { get; set; }
        //other properties 
        //Unmapped property: Since it's value depends on the Comments collection
        //we don't need to define the setter. If the collection is null, it'll
        //return zero.
        public int NumberOfComments
        {
            get
            {
                return this.Comments?.Count() ?? 0;
            }
        }
    }
