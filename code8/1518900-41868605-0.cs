    public abstract class Objective
    {
        public bool IsObjectiveDone { get; private set; }
        public virtual void CheckIfDone();
    }
    public class ObjectiveGroup
    {
        public bool AllObjectivesDone => SubObjectives.All(a => a.IsObjectiveDone);
        public Objective[] SubObjectives { get; private set; }
        public static ObjectiveGroup Create(TypeOfQuest aType, Requirements[] aReq)
        { /* factory implementation */ }
    }
