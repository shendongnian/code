    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int DropsLeft = 5;
        private string DataFormatName = "YourUniqueDataFormatNameHere";
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            PictureBox[] pbs = new PictureBox[] { pictureBox2, pictureBox3, pictureBox4, pictureBox5 };
            foreach (PictureBox pb in pbs)
            {
                pb.AllowDrop = true;
                pb.DragEnter += Pb_DragEnter;
                pb.DragDrop += Pb_DragDrop;
            }
        }
        private void PictureBox1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataObject data = new DataObject(DataFormatName, pictureBox1);
                pictureBox1.DoDragDrop(data, DragDropEffects.Copy);
            }
        }
        private void Pb_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormatName))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void Pb_DragDrop(object sender, DragEventArgs e)
        {
            DropsLeft--;
            // retrieve the data
            PictureBox pb = (PictureBox)e.Data.GetData(DataFormatName);
            if (DropsLeft == 0)
            {
                MessageBox.Show("No more drops left!");
                pb.Enabled = false;
                pb.BackColor = Color.Red; // for visual effect
            }
        }
    }
