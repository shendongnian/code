    public partial class LMS_ClassDiscussion
        {
            public LMS_ClassDiscussion()
            {
                LMS_ClassDiscussionchild = new List<LMS_ClassDiscussion>();
            }
            public int ClassDiscussionID { get; set; }
            public int? ParentClassDiscussionID { get; set; }
            public string Discussion { get; set; }
            public string DiscussionTitle { get; set; }
            public LMS_ClassDiscussion _LMS_ClassDiscussion { get; set; }
            public List<LMS_ClassDiscussion> LMS_ClassDiscussionchild { get; set; }
        }
