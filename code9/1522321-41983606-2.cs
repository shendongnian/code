      public partial class Form1 : Form
      {
        public Form1()
        {
            InitializeComponent();
        }
        internal void testfunc(Label lbl, ColorValues newcolor)
        {
            lbl.BackColor = newcolor;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            testfunc(label1, ColorValues.NormalFont);
        }
    }
    public static class ColorValues
    {
        // Private variable to hold font once instantiated
        public static System.Drawing.Color NormalFont{ get{ return Color.AliceBlue;}}
    }
    /*  public struct ColorValue
    {
        public static System.Drawing.Color NormalFont = Color.AliceBlue;
    }*/
