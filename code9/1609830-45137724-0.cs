    public partial class Form1 : Form
    {
        public int Status { get; set; }
        public Form1()
        {
            InitializeComponent();
           
        }
        private void ProfileChanged()
        {
            foreach (var child in this.MdiChildren)
            {
                if (child is Form1)
                {
                (child as Form1).Status = 1;
                  child.Close();
                }
            }
        }
    }
