    public static void EnumerateTree(Comment comment, int depth, IEnumerable<Comment> collection)
    {
        comment.Depth = depth;
        foreach(var child in collection.Where(c => c.ReplyId.HasValue && c.ReplyId == comment.Id))
        {
            comment.Children.Add(child);
            EnumerateTree(child, depth + 1, collection);
        }
    }
