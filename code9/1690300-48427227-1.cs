    static void Main(string[] args)
    {
        Program obj = new Program();
        var parentOfContent5 = obj.GetParentOfOrNull(5, obj.getdata().contentObjects);
        Console.WriteLine(parentOfContent5.ContentObjectId); // yields 4
        Console.ReadLine();
    }
    private ContentObjects GetParentOfOrNull(int id, ContentObjects root)
    {
        if (root.ChildContentObjects == null)
        {
            return null;
        }
        foreach (ContentObjects c in root.ChildContentObjects)
        {
            // If a direct child has the requested ID, we are done.
            if (c.ContentObjectId == id)
            {
                return root;
            }
            // Otherwise, recurse deeper down.
            var found = GetParentOfOrNull(id, c);
            if (found != null)
            {
                return found;
            }
        }
        // Nothing found.
        return null;
    }
