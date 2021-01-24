    public interface IGettable
    {
        int GetSomething (Criteria crit);
    }
    public class Criteria
    {
        public CriteriaType type {get; set;};
        public int a {get; set;};
        public int b {get; set;};
        ...
    }
    public enum CriteriaType
    {
        ClassOneCriteria,
        ClassTwoCriteria
    }
    public class ClassOne : IGettable
    {
        public int GetSomething (Criteria crit) 
        { 
            if (crit.type != CriteriaType.ClassOneCriteria)
                throw new Exception("Invalid criteria type for Class One");
            ...
        }
    }
