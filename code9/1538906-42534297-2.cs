    public static class Extension{
        public static IEnumerable<Transform> GetChildren(this Transform tr)
        {
            List<Transform> children = new List<Transform>();
            foreach (Transform child in tr)
            {
                children.Add(child);
            }
            // You can make the return type an array or a list or else.
            return children as IEnumerable<Transform>;
        }
    }
