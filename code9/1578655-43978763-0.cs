    public interface IAssignable
    {
        IAssignable AssignMe { get; set; }
    }
    public class A : IAssignable
    {
        public IAssignable AssignMe { get; set; }
    }
    public class B : IAssignable
    {
        public IAssignable AssignMe { get; set; }
    }
    
    // You will be able to instantiate this class with either A or B and both must be valid
    public class GenericAssignExample<T> where T : IAssignable
    {
        // here, T refers to either A or B.
        private T _assignable;
    
        public void Valid(T toAssign)
        {
            // assigning either an A or B to the interface... 
            // always valid, both implement it
            _assignable.AssignMe = toAssign;
        }
    
        public void AlsoValid(T toAssign)
        {
            // assigns interface to interface. Always valid.
            _assignable.AssignMe = toAssign.AssignMe;
        }
    
        public void AlsoValidAsWell(T toAssign)
        {
            // assigns either an A to an A
            // or a B to a B.
            // both always valid.
            _assignable = toAssign;
        }
    
        public void Invalid(T toAssign)
        {
            // this tries to assign an interface to either an A or a B
            // always invalid.
            _assignable = toAssign.AssignMe;
        }
    }
