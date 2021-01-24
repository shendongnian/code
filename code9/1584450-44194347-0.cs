    namespace Model
    {
        public class Person
        {
            public int PersonID { get; set; }
            public string Name { get; set; }
            public override bool Equals(object o)
            {
                return this.PersonEquals(o);
            }
        }
    }
    static class Extensions
    {
        public static bool PersonEquals(this object person1, object person2)
        {
            if (person1.GetType() != person2.GetType())
            {
                return false;
            }
            dynamic d1 = person1, d2 = person2;
            return d1.PersonID == d2.PersonID && d1.Name == d2.Name;
        }
    }
