    public interface IAssignmentRepository
    {
        IEnumerable<CreateAssignment> Assignments { get; }
    }
    public class AssignmentRepository : IAssignmentRepository
    {
        public IEnumerable<CreateAssignment> Assignments
        {
            get
            {
                return new List<CreateAssignment>()
                {
                    new CreateAssignment(),
                    new CreateAssignment()
                };
            }
        }
    }
     
