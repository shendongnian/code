    public interface IEmployee {
        void StartProject();
        void DoWork();
    }
    
    public abstract class EmployeeBase : IEmployee {
        public void StartProject() {
            AnnounceProjectToNewspapers();
            DoActualWork();
            PutProductOnMarket();
        }
        
        void IEmployee.DoWork() {
            // Maybe set a flag to see whether the work has been already done by calling StartProject().
            this.DoActualWork();
        }
    
        protected abstract void DoActualWork();
    
        private void AnnounceProjectToNewspapers() { }
        private void PutProductOnMarket() { }
    }
    
    public class Employee : EmployeeBase {
        protected override void DoActualWork() {
            // Log system Action
        }
    }
    
    public class Engineer : Employee {
        protected override void DoActualWork() {
            // Build things.
        }
    }
    
    public class Salesman : Employee {
        protected override void DoActualWork() {
            // Design leaflets.
        }
    }
    
    public class Manager : Employee {
        protected override void DoActualWork() {
            DoWorkInternal();
        }
    
        private void DoWorkInternal() {
            foreach (var subordinate in subordinates)
                subordinate.DoWork();
        }
    
        private List<IEmployee> subordinates;
    }
