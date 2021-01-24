    namespace Core.Nodes
    {
        public abstract class Node<T> where T : Media.Medium
        {       
            public Zone<T> ParentZone;
    
            //...
        }
    }
