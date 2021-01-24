    class Program
    {
        static void Main(string[] args)
        {
            List<ParentContainer<ChildFoo>> ca = new List<ParentContainer<ChildFoo>>();
            ProcessContainers processor = new ProcessContainers();
            ca.Add(new ChildContainerA { fooList = new List<ChildFoo>() });
            ca.Add(new ChildContainerA { fooList = new List<ChildFoo>() });
            ca.Add(new ChildContainerA { fooList = new List<ChildFoo>() });
            ca.Add(new ChildContainerB { fooList = new List<ChildFoo>() });
            processor.Process(ca);
        }
    }
    public abstract class ParentContainer<T> where T: ParentFoo
    {
        public List<T> fooList;
    }
    //Let there be many different ChildContainers with different types.
    public class ChildContainerA : ParentContainer<ChildFoo>
    {
    }
    public class ChildContainerB : ParentContainer<ChildFoo>
    {
    }
    public class ProcessContainers
    {
        public void Process<T>(List<ParentContainer<T>> childContainers) where T : ParentFoo
        {
            foreach(var item in childContainers)
            {
                foreach(var foo in item.fooList)
                {
                    foo.Porcess();
                }
            }
        }
    }
    public abstract class ParentFoo
    {
        public string name;
        public abstract void Porcess();
    }
    public class ChildFoo : ParentFoo
    {
        public override void Porcess()
        {
            //Do some processing
        }
    }
