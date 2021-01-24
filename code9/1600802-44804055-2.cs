        public class ViewModel
        {
            public ObservableCollection<string> MyLabels { get; set; }
    
            public ViewModel()
            {
                if (MyLabels == null) MyLabels = new ObservableCollection<string>();
                for (int i = 0; i < 5; i++)
                {
                    MyLabels.Add("string " + i);
                }
            }
        }
