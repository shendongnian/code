    public abstract class First {
        public void Work() {
            if (!CheckPreconditions()) {
                // Abort the job
                return;
            }
            DoWork();
        }
        protected abstract void DoWork();
    }
    
    public class Second : First {
        protected override void DoWork() {
            base.Work();
        }
    }
