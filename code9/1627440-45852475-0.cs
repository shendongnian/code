    public class Person
    {
        public int Toys { get; };
        private List<Person> childrens;
        public Person(int toys, List<Person> childrens)
        {
            ToysInput = toysInput;
            childrens = childrenInput;
        }
        public int SumToys(List<Person> children)
        {
            var total = toys;
            for(int i = 0; i < children.Count; i++)
            {
                toysTotal += children[i].Toys;
            }
            return total;
        }
    }
