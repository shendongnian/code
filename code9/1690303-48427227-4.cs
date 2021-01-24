    static void Main(string[] args)
    {
        Program obj = new Program();
        var path = obj.GetPathTo(5, obj.getdata().contentObjects);
        // prints 1, 4
        foreach (ContentObjects o in path)
        {
            Console.WriteLine(o.ContentObjectId);
        }
        Console.ReadLine();
    }
    // returns null if id could not be found
    private IEnumerable<ContentObjects> GetPathTo(int id, ContentObjects root)
    {
        if (root.ChildContentObjects != null)
        {
            foreach (ContentObjects c in root.ChildContentObjects)
            {
                if (c.ContentObjectId == id)
                {
                    // If a direct child has the requested ID, we are the first parent.
                    return new[] { root };
                }
                else
                {
                    // Recurse deeper down.
                    var found = GetPathTo(id, c);
                    if (found != null)
                    {
                        // We found something deeper down. Since we are part of the
                        // path, append own id.
                        return new[] { root }.Concat(found);
                    }
                }
            }
        }
        return null;
    }
