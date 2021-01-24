    static void Main(string[] args)
    {
        Program obj = new Program();
        var parents = obj.GetParentsOf(5, obj.getdata().contentObjects);
        Console.WriteLine(parents.Count()); // yields 1
        Console.WriteLine(parents.First().ContentObjectId); // yields 4
        Console.ReadLine();
    }
    private IEnumerable<ContentObjects> GetParentsOf(int id, ContentObjects root)
    {
        if (root.ChildContentObjects != null)
        {
            foreach (ContentObjects c in root.ChildContentObjects)
            {
                // If a direct child has the requested ID, we are a parent.
                if (c.ContentObjectId == id)
                {
                    yield return root;
                }
                // Recurse deeper down.
                foreach (ContentObjects found in GetParentsOf(id, c))
                {
                    yield return found;
                }
            }
        }
    }
