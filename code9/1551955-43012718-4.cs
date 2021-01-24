    public abstract class AttributeCollectionBase
    {
        protected virtual List<IAttribute> Attributes { get; } = new List<IAttribute>();
        protected virtual IEnumerable<IAttribute> Get(AttributeCategory category)
        {
            return Attributes.Where(a => a.Category == category);
        }
    
        protected AttributeCollectionBase()
        {
            // Yup, we'll need this one place with the constructor that lists the "default" attributes... Might be for the best, though.
            Attributes.Add(new Strength());
            Attributes.Add(new Stamina());
            Attributes.Add(new Accuracy());
            Attributes.Add(new Initiative());
        }
    }
