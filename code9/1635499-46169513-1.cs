        public IsLoading{get;set}=true;
        public MainViewModel()
        {
        GetVideoItem().ContinueWith(result=>{VideoItems = new ObservableCollection<MainMenuItem>(result);
                                    IsLoading=false;});
        }
