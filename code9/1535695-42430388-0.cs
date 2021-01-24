    public abstract class A{
        protected void onEndMethod(){
            //end !
        }
        protected void Update(){
            DoUpdate();
            onEndMethod();
        }
        protected abstract void DoUpdate();
    }
    
    
    public class B : A{
        protected override void DoUpdate()
        {
          // B class specific code
        }
    }
