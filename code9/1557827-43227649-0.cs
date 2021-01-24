    public class MyCollection : Collection<Section>
    {
        public Section this[string nameValue]
        {
            get
            {
                return this.FirstOrDefault(o => o.Name == nameValue);
            }
        }
    }
