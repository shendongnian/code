    partial class MyEntity
    {
        private string m_commentText = null;
        public string CommentText
        {
            get {
                if ((m_commentText == null) && (Comment != null)) {
                    m_commentText = Encoding.UTF8.GetString(Comment);      
                }
                return m_commentText;
            }
            set {
                m_commentText = value;
                if (value != null) {
                    Comment = Encoding.UTF8.GetBytes(value);
                }
                else {
                    Comment = null;
                }
            }
        }
    }
