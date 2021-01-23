    public partial class MainWindow : Window
    {
        SqlConnection sqlConn;
        string strErrorLogPath, strErrorLogFile, strVCClientIDSelected, strFCClientIDSelected = string.empty;
        string strVCName, strFCName, strVCButtonType, strDBInstance = string.empty;
        bool blnRowSelected, blnUpdateGridLoaded;;
        bool[] blnUpdateFields = new bool[9];
        DataRowView drvRow;
        PrintDocument printDocument1 = new PrintDocument();
        PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
        bool isWeeklyReportViewerLoaded, isPhoneReportViewerLoaded, isDependentAgeReportViewerLoaded;
        BindingSource dataBindingSource = new BindingSource();
        public class Client
        {
            public string Name { get; set; }
            public DataGridRow DGRow { get; set; }
        }
        NBFoodPantry.Utilities nbuUtilities;
        public MainWindow()
        {
            InitializeComponent();
            nbuUtilities = new NBFoodPantry.Utilities(this);
        }
    }
