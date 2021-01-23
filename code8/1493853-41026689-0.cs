    public interface IStatementInformation {
        Navigation Navigation { get; set; }
    }
    public class Navigation {
        public Navigation() {
            IsNew = true;
        }
        public virtual bool IsNew { get; set; }
        public virtual bool IsCurrentStepUnlocked() {
            return true;
        }
    }
