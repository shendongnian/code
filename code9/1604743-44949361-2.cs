        public abstract class Parent
        {
            public string Id { get; set; }
            public static Parent Find(string id)
            {
                /* logic here ..*/
            }
        }
        public class Child : Parent
        {
            public string Name { get; set; }
            public new static Child Find(string id)
            {
                /* logic here */
            }
        }
