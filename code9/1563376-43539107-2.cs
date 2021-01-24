    using System.Windows;
    namespace ProjectLibrary
    {
    public class MyViewModel : Notifiable
    {
        public MyViewModel() :this(false) {
        }
        public MyViewModel(bool Execute) {
            if (Execute) {
                SomeText = "Execution data";
            } else {
                SomeText = "Design Data";
            }
            SomeButtonVisibility = Visibility.Visible;
        }
        private string _someText;
        public string SomeText { get { return _someText; } set { _someText = value; RaisePropertyChanged("SomeText"); } }
        private Visibility _someButtonVisibility;
        public Visibility SomeButtonVisibility { get { return _someButtonVisibility; } set { _someButtonVisibility = value; RaisePropertyChanged("SomeButtonVisibility"); } }
     }
    }
