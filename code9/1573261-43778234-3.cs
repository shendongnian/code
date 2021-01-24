    public static class ColumnTextListExtension
    {
        public static void Add(this ColumnText ct, List<IElement> elements)
        {
            foreach (IElement e in elements)
            {
                ct.AddElement(e);
            }
        }
    }
