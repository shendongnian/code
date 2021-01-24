    var viewModel = SimpleIoc.Default.GetInstance<MyViewModel>("contextIdentifier");
    viewModel.ID = "contextIdentifier";
    
    public class MyViewModel : ViewModelBase
    {
      public string ID { get; set; }
    }
