    public class MyClass
    {
        private int Size { get; set; }
        private int[] Nodes { get; set; }
    
        public MyClass()
        {
            Size = 0;
            Nodes = new int[5];
        }
    
        public void EnlargeIfNeeded()
        {
            if (Size == Nodes.Length)
            {
                Array.Resize(ref Nodes, Nodes.Length * 2);
            }
        }
    }
