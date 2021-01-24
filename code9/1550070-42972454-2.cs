    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(string cell1, string cell2, string cell3, string cell4)
        {
            InitializeComponent();
            //Save data to our list using global class that
            Global.SetRow = new Global.GridRows()
            {
                Cell_1 = cell1,
                Cell_2 = cell2,
                Cell_3 = cell3,
                Cell_4 = cell4
            };
        }
    }
 
