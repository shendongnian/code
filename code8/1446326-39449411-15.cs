    class BaseController
    {
        public BaseManager manager;
    ...
    class RobotController1 : BaseController
    {
        // manager as RobotManager? - no it is stil BaseManager
        public void Ray(int x,int y);
    }
    
    
    class RobotController2 : BaseController
    {
        // manager as RobotManager? - yes. now it is RobotManager 
        public void Ray(int x,int y);
    
        public RobotController2()
        {
            manager = new RobotManager();
        }
    }
    
    public void Run()
    {
        var controller = new RobotController2();// you have RobotManager 
        controller.manager = new BaseManager();// it is again BaseManager
    }
