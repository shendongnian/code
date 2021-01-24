     public class QueryTreeNode<TEntity>
     {
        public int Id {get; set;}  // Create Identity for Query Node
        public int ParentId { get; set;} // Tree Parent, if none Id = 0
        // Order of the expressions displayed, use this and Binary Operation Order 
        // to determine how to resolve siblings e.g `And` before `Or` 
        public int Order { get; set; } 
        public string PropertyName { get; set; }
        public FilterCondition FilterCondition { get; set; }
        public string Value { get; set; }
        public ExpressionCombine {get; set;} //= ExpressionCombine.None;
     }
