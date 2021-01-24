    public class ViewModel
    {
    		ObservableCollection<Names> allNames = new ObservableCollection<GroupedReportModel>();
            public ObservableCollection<Names> AllNames
            {
                get { return allNames; }
                set { SetProperty(ref allNames, value); }
            }
    }
