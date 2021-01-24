    public partial class SYOWindow : Window
    {
        //  ...stuff
        //  C#6 version -- but if you're on an earlier version of C#, you'll get 
        //  "DataContext is a property but is used like a type" and a red squiggly.
        //public SYOWindowViewModel ViewModel => (SYOWindowViewModel)DataContext;
        //  C#<=5. This works fine in C#6 as well.
        public SYOWindowViewModel vm { get { return (SYOWindowViewModel)DataContext; } }
        //  ...more stuff
     }
