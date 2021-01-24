    public class MainViewModel
    {
        IMainViewCallbacks Calllbacks = null;
        public MainViewModel(IMainViewCallbacks cb)
        {
           // stash the callbacks for later.
           this.Callbacks = cb;
        }
    
        // pseudocode for the command that consumes the callback
        public ICommand .... 
        {
            Execute() { this.Callbacks.GetPathViaOpenDialog(); }
        } 
    }
