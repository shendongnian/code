    public class ListElementHandler : IElementHandler
    {
        List<IElement> elements = new List<IElement>();
        public List<IElement> List => elements;
        public void Add(IWritable w)
        {
            if (w is WritableElement)
            {
                foreach (IElement e in ((WritableElement)w).Elements())
                {
                    elements.Add(e);
                }
            }
        }
    }
