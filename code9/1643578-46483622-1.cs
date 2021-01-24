    public class ScrewyWrapper
    {
        protected dynamic ActualWrapper = new ScrewyDynamicWrapper();
        public int? PropertyA
        {
            get { return ActualWrapper.PropertyA; }
            set { ActualWrapper.PropertyA = value; }
        }
        public string PropertyB
        {
            get { return ActualWrapper.PropertyB; }
            set { ActualWrapper.PropertyB = value; }
        }
    }
