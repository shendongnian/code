     public partial class Form1 : Form
    {
        System.Drawing.Graphics graphics;
        System.Drawing.Rectangle rectangle;
        public Form1()
        {
            InitializeComponent();
            comboBox1.Enter += ComboBox1_Enter;
            comboBox1.Leave += ComboBox1_Leave;
        }
        private void ComboBox1_Leave(object sender, EventArgs e)
        {
            graphics.Clear(this.BackColor);
        }
        private void ComboBox1_Enter(object sender, EventArgs e)
        {
            ChangeActiveControlStyle((Control)sender);
        }
        private void ChangeActiveControlStyle(Control control)
        {
            graphics = this.CreateGraphics();          
            rectangle = new System.Drawing.Rectangle(control.Location.X -2, control.Location.Y-2, control.Width+4, control.Height+4);
            graphics.FillRectangle(Brushes.Yellow, rectangle);
        }
    }
