    public class Doer
    {
        public virtual void Do()
        {
            //do stuff.
        }
        public virtual void Other()
        {
            //do stuff.
        }
    }
    public class AspectDoer : Doer
    {
        public override void Do()
        {
            LogCall("Do");
            base.Do();
        }
        public override void Other()
        {
            LogCall("Other");
            base.Other();
        }
        private void LogCall(string method)
        {
           //Record call 
        }
    }
