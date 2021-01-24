    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        RichTextBox console = new RichTextBox();
        private void Form1_Load(object sender, EventArgs e)
        {
            console.Size = this.ClientSize;
            console.Top = 0;
            console.Left = 0;
            console.BackColor = Color.Black;
            console.ForeColor = Color.White;
            console.WordWrap = false;
            console.Font = new Font("Consolas", 20);
            console.Text = "The djinni speaks. \"I am in your debt. I will grant one wish!\"--More--";
            console.AppendText("\n.......");
            console.SelectionColor = Color.Blue;
            console.AppendText("♦♦");
            console.SelectionColor = Color.White;
            console.AppendText("...._________..___");
            this.Controls.Add(console);
            this.Resize += Form1_Resize;
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            console.Size = this.ClientSize;
        }
    }
