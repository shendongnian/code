    public class MyObject
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
       
        public override bool Equals(object obj)
        {
            MyObject o = obj as MyObject;
            if (o == null)
                return false;
            if (this.Name != o.Name)
                return false;
            return true;
        }
        /// <summary>
        /// Serves as the default hash function. 
        /// </summary>
        /// <returns>
        /// A hash code for the current object.
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    public class Program
    {
        static public void Main()
        {
            MyObject o1 = new MyObject()
            {
                Name = "a",
                Price = 1
            };
            MyObject o2 = new MyObject()
            {
                Name = "b",
                Price = 1
            };
            MyObject o3 = new MyObject()
            {
                Name = "a",
                Price = 1
            };
            Console.WriteLine("o1 == o2: {0}", o1.Equals(o2));
            Console.WriteLine("o1 == o3: {0}", o1.Equals(o3));
            Console.ReadKey();
        }
    }
