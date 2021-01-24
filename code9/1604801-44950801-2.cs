    public class Language
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is Language)
            {
                return ((Language)obj).Id == Id;
            }
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
