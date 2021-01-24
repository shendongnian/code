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
            if (!left.IsAsynchronous) 
            {
                if (!right.IsAsynchronous) 
                {
                    return left.IsSatisfiedBy(o) && right.IsSatisfiedBy(o);
                }
                else
                {
                    if (!left.IsSatisfiedBy(o)) return false;
                    return right.IsSatisfiedBy(o);
                } 
            }
            else if (!right.IsAsynchronous) 
            {
                if (!right.IsSatisfiedBy(o)) return false;
                return left.IsSatisfiedBy(o);
            }
            else
            {
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
    }
