    public class AndSpecification : ISpecification
    {
        private ISpecification left;
        private ISpecification right;
    
        public AndSpecification(ISpecification _left, ISpecification _right) 
        {
            if (_left == null || _right == null) throw new ArgumentNullException();        
            left = _left;
            right = _right;
        }
    
        public bool IsAsynchronous { get { return left.IsAsynchronous || right.IsAsynchronous; }
        
        public override bool IsSatisfiedBy(object o) 
        {
            if (!this.IsAsynchronous)            
                return leftCondition.IsSatisfiedBy(o) && rightCondition.IsSatisfiedBy(o);
            
            Parallel.Invoke(
    	        () => {
    		        if (!left.IsSatisfiedBy(o)) return false;
    	        },
            	() => {
    		        if (!right.IsSatisfiedBy(o)) return false;
    	        }
            );
            
            return true;
        }
    }
