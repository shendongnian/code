    //Code in Page
    public class MyPage : ContentPage
    {
        public MyPage()
        {
            var entry = new Entry();
            BindingContext = new MyViewModel();
            entry.SetBinding<MyViewModel>(Entry.TextProperty, vm=>vm.EntryText);
            Content = entry;
        }
    }
    //Code in ViewModel
    public class MyViewModel() : INotifyPropertyChanged
    {
        public MyViewModel()
        {
            Task.Factory.StartNew(()=> methodRunPeriodically());
        }
        string entryText;
        public string EntryText
        {
            get { return entryText; }
            set
            {
                if(entryText == value)
                    return;
                entryText = value;
                OnPropertyChanged();
            }
        }
        bool shouldRun = true;
        async Task methodRunPeriodically()
        {
            while(shouldRun)
            {
                userdata = await UserService.GetUserasync(_UserViewModel.EmployeeId);
                EntryText = userdata.FirstName;
                await Task.Delay(5000); //Run this every 5 seconds
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
    }
