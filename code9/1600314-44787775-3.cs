    [Export(typeof(IShell))]
    public class ShellViewModel : PropertyChangedBase, IShell
    {
        [Import]
        public IUserViewModel Uvm { get; set; }
    
       public void LaunchUserViewModel()
       {
          Uvm.SomeMethod(); // Your Uvm is already created 
       } 
    }
