    public class BaseDTO
    {
        internal int ID { get; set; }
    
        /// <summary>
        /// If the obj is the same type with the same id we'll consider it equal.
        /// </summary>
        public override bool Equals(object obj)
        {
            if(obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }
    
            return this.GetType().GetHashCode() == obj.GetType().GetHashCode() &&
                    this.ID == (BaseDTO)obj.ID;
        }
    
        /// <summary>
        /// If you override equals, you should override gethashcode.  
        /// http://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode#263416
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
    
                hash = hash * 23 + this.GetType().GetHashCode();
                hash = hash * 23 + this.ID;
    
                return hash;
            }
        }
    }
    
    public class CarDTO : BaseDTO
    {
        public int CarID
        {
            get { return this.ID; }
            set { this.ID = value; }
        }
        public string Manufacturer { get; set; }
        public List<CarOptionDTO> CarOptions { get; set; }
    }
