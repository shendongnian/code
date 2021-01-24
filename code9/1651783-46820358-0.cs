    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ArrayList listDataSource = new ArrayList();
            //add some members to list
            listDataSource.Add(new Record(1, "4 oclock", 10, 5, 7, 8));
            listDataSource.Add(new Record(1, "5 oclock", 11, 4, 4, 9));
            chart1.Series["Series1"].XValueMember = "TimeStamp";
            chart1.Series["Series1"].YValueMembers = "High, Low, Open, Close";
            chart1.Series["Series1"].CustomProperties = "PrieceDownColor=Red,PriceUpColor=green";
            chart1.Series["Series1"]["ShowOpenClose"] = "Both";
            chart1.DataManipulator.IsStartFromFirst = true;
            chart1.DataSource = listDataSource;
            chart1.DataBind();
        }
        
    }
    public class Record
    {
        int id;
        string time_stamp;
        double open, close, high, low;
        public Record(int id, string time_stamp, double open, double close, double high, double low)
        {
            this.id = id;
            this.time_stamp = time_stamp;
            this.open = open;
            this.close = close;
            this.high = high;
            this.low = low;
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string TimeStamp
        {
            get { return time_stamp; }
            set { time_stamp = value; }
        }
        public double Open
        {
            get { return open; }
            set { open = value; }
        }
        public double Close
        {
            get { return close; }
            set { close = value; }
        }
        public double High
        {
            get { return high; }
            set { high = value; }
        }
        public double Low
        {
            get { return low; }
            set { low = value; }
        }
    }
