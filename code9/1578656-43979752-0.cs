    public interface IAssignable
    {
        IAssignable AssignMe { get; set; }
    }
    public class GenericAssignExample
    {
        private IAssignable _assignable;
        public void Valid(IAssignable toAssign)
        {
            _assignable.AssignMe = toAssign;
        }
        public void AlsoValid(IAssignable toAssign)
        {
            _assignable.AssignMe = toAssign.AssignMe;
        }
        public void AlsoValidAsWell(IAssignable toAssign)
        {
            _assignable = toAssign;
        }
        public void Invalid(IAssignable toAssign)
        {
            _assignable = toAssign.AssignMe;
        }
    }
