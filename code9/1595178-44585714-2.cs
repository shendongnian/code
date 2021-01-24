    public class Pip
    {
        public string Color { get; set; }
        public override bool Equals(object obj)
        {
            if (!(obj is Pip))
                return false;
            Pip p = (Pip)obj;
            return (p.Color == Color);
        }
        public override int GetHashCode()
        {
            return String.Format("{0}", Color).GetHashCode();
        }
    }
