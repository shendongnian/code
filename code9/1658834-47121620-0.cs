    return new Post
    {
        Title = model.Title,
        Content = model.Content,
        PostTags = model.SomeStringWithTags.Split(new []{' '})
              .Select(s => 
              {
                 new PostTag
                 {
                     Tag = new Tag { Name = s }
                 }
              }
              .ToList() // .. needed because of the `ICollection`
     };
