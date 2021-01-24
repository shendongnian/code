    public class HomePage : BasePage<HomePage>, IPage {
        public virtual bool EvaluateLoadStatus() { //MARK AS VIRTUAL
            //Implementation
        }        
    }
    
    public abstract class BaseUserPage : HomePage, IPage {
        public abstract override bool EvaluateLoadStatus();
    }
    public class UserPage : BaseUserPage , IPage {
        public abstract override bool EvaluateLoadStatus(){
            //new implementation
        }
    }
