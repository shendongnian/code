            namespace <your namespace>
            {               
                public abstract class Abc
                {
            
                    public abstract event EventHandler<EventArgs> MesReceived;
                }
            
    #pragma warning disable 0067
                public class MyClass: Abc
                {
                    public override event EventHandler<EventArgs> MesReceived;
        
        //constructers
        //methodes
        //etc
                }
    #pragma warning restore 0067
            }
