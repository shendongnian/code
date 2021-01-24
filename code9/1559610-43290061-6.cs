    public class Person {
       public string Name { get; set; }
       public Int16 Age { get; set; }
       public Int16 Height { get; set; }
       public string Hobby { get; set; }
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Height: {Height}, Hobby: {Hobby}";
        }
    }
