    public class Person 
    {
        public int Age;
        public string Name;
        public IdInfo IdInfo;
        public Person ShallowCopy()
        {
           return (Person) this.MemberwiseClone();
        }
        public Person DeepCopy()
        {
           Person other = (Person) this.MemberwiseClone();
           other.IdInfo = new IdInfo(IdInfo.IdNumber);
           other.Name = String.Copy(Name);
           return other;
        }
    }
