    public class NameColection : List<NameVariable>
    {
        public NameVariable this[string name]
        {
            get
            {
                return this.FirstOrDefault(n => n.Name == name);
            }
        }
    }
