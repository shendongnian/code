OtherView.xaml
    <ContentView>
        <StackLayout>
            <Label Text="{Binding MyText}" />
        </StackLayout>
    </ContentView>
OtherViewModel.cs
    public class OtherViewModel : INotifyPropertyChanged
    {
        // Do you own implementation of INotifyPropertyChanged
    
        private string myText;
        public string MyText
        {
           get { return this.myText; }
           set
           {
               this.myText = value;
               this.OnPropertyChanged("MyText");
           }
        }
        
        public OtherViewModel(string text)
        {
            this.MyText = text;
        }
    }
MainViewModel.cs
    public class MainViewModel: INotifyPropertyChanged
    {
        // Do you own implementation of INotifyPropertyChanged
    
        private OtherViewModel otherVM;
        public OtherViewModel OtherVM
        {
           get { return this.otherVM; }
        }
        
        public MainViewModel()
        {
            // Initialize your other viewmodel
            this.OtherVM = new OtherViewModel("Hello world!");
        }
    }
