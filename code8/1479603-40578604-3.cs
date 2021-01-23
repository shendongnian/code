    public class Person : ICloneable
    {
        public string Name { get; set; }
        public Person Clone()
        {
            return new Person() { Name=this.Name }; // string copy
        }
        object ICloneable.Clone() { return Clone(); } // interface calls specific function
    }
    public struct Project : ICloneable
    {
        public Person Leader { get; set; }
        public string Name { get; set; }
        public int[] Steps { get; set; }
        public Project Clone()
        {
            return new Project()
            {
                Leader=this.Leader.Clone(),         // calls Clone for copy
                Name=this.Name,                     // string copy
                Steps=this.Steps.Clone() as int[]   // shallow copy of array
            };
        }
        object ICloneable.Clone() { return Clone(); } // interface calls specific function
    }
