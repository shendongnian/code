    public partial class DataBinding : Window
    {
      public DataBinding()
      {
        InitializeComponent();
        DataContext = new DataBindingViewModel();
      }
    }
    public class DataBindingViewModel
    {
      public DataBindingViewModel()
      {
        Setupviewmodel();
      }
      private void Setupviewmodel()
      {
        TextString = "this worked";
      }
      public string TextString { get; set; }
    }
