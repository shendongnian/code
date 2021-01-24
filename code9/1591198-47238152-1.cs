    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.DrawItem += TabControlOnDrawItem;
        }
        private FontStyle HasNotification(string tabText)
        {
            return tabText.Equals("Notes") && true 
                       ? FontStyle.Bold
                       : FontStyle.Regular;
        }
        private void TabControlOnDrawItem(object sender, DrawItemEventArgs e)
        {
            var tab = (TabControl) sender;
            var tabText = tab.TabPages[e.Index].Text;
            e.Graphics
             .DrawString(tabText
                         , new Font(tab.Font.FontFamily
                                    , tab.Font.Size
                                    , HasNotification(tabText))
                         , Brushes.Black
                         , e.Bounds
                         , new StringFormat
                           {
                               Alignment = StringAlignment.Center,
                               LineAlignment = StringAlignment.Center
                           });
        }
    }
