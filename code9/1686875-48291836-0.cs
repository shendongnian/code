    namespace LotRunPlotGrid
    {
        public class ShellViewModel : PropertyChangedBase, IShell {
            private LotRunPlotGridViewModel myGrid = new LotRunPlotGridViewModel();
    
            public LotRunPlotGridViewModel MyGrid {
                get { return myGrid; }
                set {
                    myGrid = value;
                    NotifyOfPropertyChanged();
                }
            }
        }
    }
