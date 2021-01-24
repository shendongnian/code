    using System.Data.Entity.Infrastructure;
    
    var tags = TagConverter.FetchTags(postText);
    var newTags = tags.Select(t => t.Title);
    var savedTags = _db.Tags.Where(t => newTags.Contains(t.Title)).ToList();
    var notSavedTags = tags.Where(t => savedTags.All(st => st.Title != t.Title)).ToList();
    var insertedTags = _db.Tags.AddRange(notSavedTags).ToList();
    insertedTags.AddRange(savedTags);
    _db.SaveChanges();
    var updatedPost = post();
    _db.Posts.Attach(updatedPost);
    updatedPost.Title = postText;
    
    var entry = _db.Entry(updatedPost);
    entry.Property(e => e.Title).IsModified = true;
    foreach (var tag in insertedTags)
    {
       ((IObjectContextAdapter)DbContext).ObjectContext.ObjectStateManager.
       ChangeRelationshipState(updatedPost, tag, e => e.Tags, EntityState.Added);
    } 
    _db.SaveChanges();
