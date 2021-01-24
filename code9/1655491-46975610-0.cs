    public abstract class Abc
    {
       public virtual event EventHandler<MsgEventHandler> MesReceived;
    }
    
    public MyClass: Abc
    {       
       // compiles without this line:
       public override event EventHandler<MsgEventHandler> MesReceived;
    }
