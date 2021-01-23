    public class MyController : ControllerBase
    {
        private MyClass _myClass;
        public MyController(MyClass myClass)
        {
            _myClass = myClass;
        }
