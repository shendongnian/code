        public class PostAndRegion
        {
            public Post Post{get;set;}
            public Region Region {get;set;}
        }
        public class MyCompositeModel
        {
            public IList<PostAndRegion> PostsAndRegions{get;set;}
            public UserInfo MyUserInfo{get;set;}
        }
