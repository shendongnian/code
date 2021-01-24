    public partial class form1 : Form
    {
      public form1()
           {
            InitializeComponent();
            trackBar1.Maximum = 4;
            trackBar1.SmallChange = 1;
            trackBar1.LargeChange = 1;
            trackBar1.TickFrequency = 1;//This is will set your ticking steps lenght
            }
      private void TrackBar1_Scroll(object sender, EventArgs e)
            {           
            toolTip1.SetToolTip(trackBar1, "% "+trackBar1.Value*25).ToString());
            }
    }
