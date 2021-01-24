    public class TaskBase
    {
        public string SomeProperty { get; set; }
    }
    public class Node 
    {
        public TaskBase Data { get; private set;}
        public Node Next { get; set; }
        public Node Prev { get; set; }
        public Node(TaskBase data)
        {
            Data = data;
        }
        public Node Clone()
        {
            // Now all the data part is the same object
            // so changing Data.SomeProperty in one list will be 
            // reflected in both. But the Next and Prev properties
            // are independent. 
            return new Node(Data);
        }
    }
