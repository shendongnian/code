    public partial class SYOWindow : Window
    {
        //  ...stuff
        //  C#6 version -- but I think you may be on C#5
        //public SYOWindowViewModel ViewModel => (SYOWindowViewModel)DataContext;
        //  C#5. This works fine in C#6 as well.
        public SYOWindowViewModel vm { get { return (SYOWindowViewModel)DataContext; } }
        //  ...more stuff
     }
