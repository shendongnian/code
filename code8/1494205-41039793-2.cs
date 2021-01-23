    partial class MyEntity
    {
        public string CommentText
        {
            get {
                if (Comment != null) {
                    return Encoding.UTF8.GetString(Comment);      
                }
                else {
                    return null;
                }
            }
            set {
                if (value != null) {
                    Comment = Encoding.UTF8.GetBytes(value);
                }
                else {
                    Comment = null;
                }
            }
        }
    }
