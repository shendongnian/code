    public class A
    {
        // You inject some service IServiceX
        public A(IServiceX serviceX) 
        {
            ServiceX = serviceX;
        }
    
        private IServiceX ServiceX { get; }
    
        // B is associated to A
        public B B { get; set; }
    
        // So you can do some stuff calling the whole ServiceX
        public void DoStuff()
        {
             ServiceX.DoWhatever();
        }
    }
    
    public class B 
    {
        public A(IServiceY serviceY) 
        {
            ServiceY = serviceY;
        }
    
        private IServiceY ServiceY { get; }
        // C is associated to B
        public C C { get; set; }
    
        public void DoStuff()
        {
             ServiceY.DoWhatever();
        }
    }
    
    public class C
    {    
        public C(IServiceZ serviceZ) 
        {
            IServiceZ = serviceZ;
        }
    
        private IServiceZ IServiceZ { get; }
    
        public void DoStuff()
        {
             IServiceZ.DoWhatever();
        }
    }
