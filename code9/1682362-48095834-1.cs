    interface IEmptyInterface {
        int EmptyInterfaceMethod1();
    }
    public class AppDelegate : UIApplicationDelegate, IEmptyInterface {
        public override UIWindow Window { get; set; }
        //The type and parameter have to be same as in the interface!
        public int EmptyInterfaceMethod1() { return 1; }
    }
