    namespace WpfExampleControlLibrary
    {
        /// <summary>
        /// Interaction logic for UserControl1.xaml
        /// </summary>
        public partial class UserControl1 : UserControl
        {
            #region Constructor
    
            public UserControl1()
            {
                InitializeComponent();
    
                GraphPens = new ObservableCollection<GraphPen>();
            }
    
            #endregion Constructor
    
            #region Public Methods
    
            #endregion Public Methods
    
            #region Dependency Properties
    
            // Pens
    
            public static PropertyMetadata GraphPenMetadata = new PropertyMetadata(null);
            public static DependencyProperty GraphPensProperty
                = DependencyProperty.Register(
                    "GraphPens",
                    typeof(ObservableCollection<GraphPen>),
                    typeof(UserControl1),
                    GraphPenMetadata);
    
            public ObservableCollection<GraphPen> GraphPens
            {
                get { return (ObservableCollection<GraphPen>)GetValue(GraphPensProperty); }
                set { SetValue(GraphPensProperty, value); }
            }
    
            // Debug Text
    
            public static PropertyMetadata DebugTextMetadata = new PropertyMetadata(null);
            public static DependencyProperty DebugTextProperty
                = DependencyProperty.Register(
                    "DebugText",
                    typeof(string),
                    typeof(UserControl1),
                    DebugTextMetadata);
    
            public string DebugText
            {
                get { return (string)GetValue(DebugTextProperty); }
                set { SetValue(DebugTextProperty, value); }
            }
    
            #endregion Dependency Properties
        }
    }
