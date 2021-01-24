    public partial class Form1 : Form
    {
        int x, y;
        private const int WIDTH = 50;
        private const int HEIGHT = 50;
        private const int VGAP = 5;
        List<Button> lstButtons = new List<Button>();
 
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            int counter = 1;
            for (int j = 0; j < 4; j++)
            {
                Button b = new Button();
                b.Left = x;
                b.Top = y;
                b.Width = WIDTH;
                b.Height = HEIGHT;
                b.Name = counter.ToString();
                counter++;
                x += VGAP + HEIGHT;
                this.Controls.Add(b);
                lstButtons.Add(b);
                
            }
            DosomethingWithButton(3);
        }
        private void DosomethingWithButton(int index)
        {
            lstButtons[index].Text = "Hello";
        }
    }
