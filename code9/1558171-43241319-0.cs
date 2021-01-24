    using (var context = new YourContext())
                {
                    //Find or Create Category
                    Category category = null;
                    if (context.Categories.Any(cat => cat.Name == post.category.Name))
                    {
                        category = context.Categories.FirstOrDefault(cat => cat.Name == post.category.Name);
                    }
                    else
                    {
                        category = new Category
                        {
                            Name = post.category.Name
                        };
                        context.Categories.Add(category);
                    }
    
                    //Find or Create Tags
                    var tags = new List<Tag>();
                    foreach (var tag in post.tags)
                    {
                        Tag targetedTag;
                        if (context.Tags.Any(t => t.Name == tag.Name))
                        {
                            targetedTag = context.Tags.FirstOrDefault(t => t.Name == tag.Name);
                        }
                        else
                        {
                            targetedTag = new Tag
                            {
                                Name = tag.Name,
                                // UrlSlug = use helper as you've said 
                            };
                            context.Tags.Add(targetedTag);
                        }
                        tags.Add(targetedTag);
                    }
    
                    var targetedPost = new Post
                    {
                        Category = category,
                        Tags = tags,
                        ArticleBody = post.articleBody,
                        Author = post.author,
                        DateCreated = post.dateCreated,
                        DateModified = post.dateModified,
                        DatePublished = post.datePublished,
                        Description = post.description,
                        Title = post.title,
                        TnImage = post.tnImage,
                        UrlSlug = post.urlSlug
                    };
    
                    context.Posts.Add(targetedPost);
    
                    context.SaveChanges();
    
                }
 
