    public interface IBaseClass
    {
        void SetController(BaseController controller);
        void Method1();
    }
    public class BaseClass : IBaseClass
    {
        private BaseController controller;
        public void SetController(BaseController controller)
        {
            this.controller = controller;
        }
        public void Method1()
        {
            var str = this.controller.RandomValue;
        }
    }
    
