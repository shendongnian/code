    return context.Contents.Where(x => x.ParentId == parentId).ToList().Select(x => 
    {
         Content content = new Content(x);
         content.GetChildContent(context);
         return content;
    }).ToList(); 
