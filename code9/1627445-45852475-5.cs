    public class Person
    {
        public int Toys { get; };
        private List<Person> children;
        public Person(int toys, List<Person> childrens)
        {
            ToysInput = toysInput;
            children = childrenInput;
        }
        public int SumToys()
        {
            var total = toys;
            for(int i = 0; i < children.Count; i++)
            {
                toysTotal += children[i].Toys;
            }
            return total;
        }
    }
