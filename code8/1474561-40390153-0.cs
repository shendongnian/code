    interface IListener 
    {
         void Listen();
         ...
    }
    class CA : A, IListener{ .... }
    class CB : B, IListener { .... }
    // to use:
    IListner listener =  useSSL ? new CA(...) : new CB(...);     
 
