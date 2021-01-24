      public static IEnumerable<Content> GetContent(int? parentId = null)
        {
            using(DSSCMSContext context = new DSSCMSContext())
            {
                return context.Contents.Where(x => x.ParentId == parentId).ToList().Select(x => 
                    {
                        Content content = new Content(x);
                        content.GetChildContent(context);
                        return content;
                    });          
            }
        }
    
        private void GetChildContent(DSSCMSContext context)
        {
            Children = context.Contents.Where(x => x.ParentId == Id).ToList().Select(x =>
            {
                Content child = new Content(x);
                child.GetChildContent(context);
    child.Dispose();
                    return child;
                });
            }
