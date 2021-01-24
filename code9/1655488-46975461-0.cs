        namespace <your namespace>
        {
        #pragma warning disable 0067
        
            public abstract class Abc
            {
        
                public abstract event EventHandler<EventArgs> MesReceived;
            }
        
            public class MyClass: Abc
            {
                public override event EventHandler<EventArgs> MesReceived;
    
    //constructers
    //methodes
    //etc
            }
        }
