    public class Subject
    {
        public virtual void Print()
        {
            Console.WriteLine("this is a print");
        }
    }
    public class SubjectProxy : Subject
    {
        public override void Print()
        {
            Console.Write("Before calling base.Print()");
            base.Print();
            Console.Write("After calling base.Print()");
        }
    }
