    using System.Collections.Generic;
    
    namespace ConsoleApp1
    {
        public class RootObject
        {
            public RootObject()
            {
                ConjunctionNode = new List<ConjunctionNode>();
            }
    
            public List<ConjunctionNode> ConjunctionNode { get; set; }
        }
    
        public class FilterNode
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }
    
        public class ConjunctionNode
        {
            public LikeNode Like { get; set; }
            public EQNode Eq { get; set; }
            public GTNode Gt { get; set; }
            public LTNode Lt { get; set; }
        }
    
        public class AndNode : ConjunctionNode
        {
        }
    
        public class OrNode : ConjunctionNode
        {
        }
    
        public class LikeNode : FilterNode
        {
        }
    
        public class EQNode : FilterNode
        {
        }
    
        public class GTNode : FilterNode
        {
        }
    
        public class LTNode : FilterNode
        {
        }
    }
