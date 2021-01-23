      private static DocumentViewer _docViewer;
 
      public MainWindow()
      {
         InitializeComponent();
         _docViewer = DocumentViewPowerPoint;
      }
 
      public static DocumentViewer GetInstance()
      {
         return _docViewer;
      }
