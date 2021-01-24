     public class ViewVM
        {
            public string ViewDisplay { get; set; }
            public Type ViewType { get; set; }
            public Type ViewModelType { get; set; }
            public UserControl View { get; set; }
            public RelayCommand Navigate { get; set; }
            public ViewVM()
            {
                Navigate = new RelayCommand(NavigateExecute);
            }
            public void NavigateExecute()
            {
                if(View == null && ViewType != null)
                {
                    View = (UserControl)Activator.CreateInstance(ViewType);
                }
                var msg = new NavigateMessage { View = View, ViewModelType = ViewModelType, ViewType = ViewType };
                Messenger.Default.Send<NavigateMessage>(msg);
            }
        }
