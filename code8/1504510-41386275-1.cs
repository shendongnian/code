    public class Student : Node<Student>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public override string ToString() { return string.Format("ID={0}, Name={1}", ID, Name); }
    }
