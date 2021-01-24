    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public RichTextBox tmpRtf = new RichTextBox();
        //Poor button name incoming...
        private void button1_Click(object sender, EventArgs e)
        {
            if (tmpRtf == null)
                tmpRtf = new RichTextBox();
            //You can add any text here and it will be shown on the label.
            this.tmpRtf.Text = "Richtextbox";
            this.UpdatePanel(this.tmpRtf);
        }
        //Custom method to update the panel for any control. Can pobably be done way better than this, but hey.
        private void UpdatePanel(object pControl)
        {
            //Checks if control is a rtf
            if(pControl is RichTextBox)
            {
                //This is your code! Ay.
                Bitmap l_bitmap = new Bitmap(this.panel1.Width / 2, this.panel1.Height / 2);
                (pControl as RichTextBox).DrawToBitmap(l_bitmap, new Rectangle(0, 0, l_bitmap.Width, l_bitmap.Height));
                this.tmpRtf.BackColor = Color.LightGray;
                this.panel1.BackgroundImage = l_bitmap;
                this.panel1.BackgroundImageLayout = ImageLayout.Center;
                this.labelControlName.Text = this.tmpRtf.Text;
                this.panel1.Refresh();
            }
        }
    }
