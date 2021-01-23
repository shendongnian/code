    public abstract class Employee
    {
        // Meant to be called by Manager class only.
        internal void FollowTheLeader()
        {
            DoActualWork();
        }
    }
    
    public class Manager : Employee
    {
        protected override void DoActualWork()
        {
            // Make gantt charts.
    
            // Also delegate.
            foreach (var subordinate in subordinates)
                // ...but then compiler stops you.
                subordinate.FollowTheLeader();
        }
    }
