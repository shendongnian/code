    public class MyVM : ViewModelBase
    {
        public MyVM()
        {
            Line.DictionaryEng = Line.DictionaryEngStub();
            Line.DictionaryRu = Line.DictionaryRuStub();
            lines = new ObservableCollection<Line>(Line.DictionaryEng.Keys.Select(k => new Line() { KeyWord = k }));
        }
        private ObservableCollection<Line> lines;
        public ObservableCollection<Line> Lines
        {
            get { return lines;  }
            set
            {
                lines = value;
                OnPropertyChanged("Lines");
            }
        }
    }
