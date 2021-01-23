    public partial class MainWindow : Window, INotifyPropertyChanged
        {
            private double itemHeight;
            private double itemWidth;
            private int layoutColumns;
            private int layoutHeight;
            private int layoutWidth;
            private Thickness verticalSpacing;
    
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
    
                InitializeDesign();
            }
    
            public double ItemWidth
            {
                get { return itemWidth; }
                set
                {
                    if (value.Equals(itemWidth))
                        return;
                    itemWidth = value;
                    OnPropertyChanged();
                }
            }
    
            public double ItemHeight
            {
                get { return itemHeight; }
                set
                {
                    if (value.Equals(itemHeight))
                        return;
                    itemHeight = value;
                    OnPropertyChanged();
                }
            }
    
            public int LayoutColumns
            {
                get { return layoutColumns; }
                set
                {
                    if (value == layoutColumns)
                        return;
                    layoutColumns = value;
                    OnPropertyChanged();
                }
            }
    
            public int LayoutWidth
            {
                get { return layoutWidth; }
                set
                {
                    if (value == layoutWidth)
                        return;
                    layoutWidth = value;
                    OnPropertyChanged();
                    UpdateCalculations();
                }
            }
    
            public int LayoutHeight
            {
                get { return layoutHeight; }
                set
                {
                    if (value == layoutHeight)
                        return;
                    layoutHeight = value;
                    OnPropertyChanged();
                    UpdateCalculations();
                }
            }
    
            public Thickness VerticalSpacing
            {
                get { return verticalSpacing; }
                set
                {
                    if (value.Equals(verticalSpacing))
                        return;
                    verticalSpacing = value;
                    OnPropertyChanged();
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void UpdateCalculations()
            {
                //Calculate the # of elements that fit on the list view
                var totalItems = (int) (LayoutWidth/ItemWidth);
                LayoutColumns = totalItems;
            }
    
            private void InitializeDesign()
            {
                LayoutWidth = 525;
                LayoutHeight = 350;
    
                ItemWidth = 100;
                ItemHeight = 100;
    
                VerticalSpacing = new Thickness(3);
            }
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
