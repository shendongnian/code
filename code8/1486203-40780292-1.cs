        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            //for c# versions below 6.0
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            //if Using c# 6.0 with Visual Studio 2015
            //Comment the above and uncomment the below
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private WaterfallDataGroup group;
        public WaterfallDataGroup Group
        {
            get { return group; }
            set { group = value; RaisePropertyChanged("Group"); }
        }
        private WaterfallDataItem currentItem;
        public WaterfallDataItem CurrentItem
        {
            get
            {
                return currentItem;
            }
            set
            {
                currentItem = value;
                RaisePropertyChanged("CurrentItem");
            }
        }
        private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            CurrentItem = await WaterfallDataSource.GetItemAsync((String)e.NavigationParameter);
            Group = await WaterfallDataSource.GetGroupByItemAsync(CurrentItem);
        }
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            // TODO: Save the unique state of the page here.
        }
        private void photo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CurrentItem.IsDataVisible = !currentItem.IsDataVisible;
            Group.Items = Group.Items.Select(x =>
            {
                x.IsDataVisible = CurrentItem.IsDataVisible;
                return x;
            }).ToObservableCollection();
        }
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
        private void DetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            CurrentItem.IsDescriptionVisible = true;
            Group.Items = Group.Items.Select(x =>
            {
                x.IsDescriptionVisible = CurrentItem.IsDescriptionVisible;
                return x;
            }).ToObservableCollection();
        }
        private void HideBtn_Click(object sender, RoutedEventArgs e)
        {
            CurrentItem.IsDescriptionVisible = false;
            Group.Items = Group.Items.Select(x =>
            {
                x.IsDescriptionVisible = CurrentItem.IsDescriptionVisible;
                return x;
            }).ToObservableCollection();
        }
