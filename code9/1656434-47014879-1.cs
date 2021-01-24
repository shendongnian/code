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
            console.Text = "The djinni speaks. \"I am in your debt. I will grant one wish!\"--More--\n";
            AppendText("\n........");
            AppendCharacter('.', 7);
            AppendCharacter('♦', 2, Color.Blue);
            AppendText("....╔═══════╗..╔═╗");
            AppendText("\n........");
            AppendCharacter('.', 8);
            AppendCharacter('♦', 2, Color.Blue);
            AppendText("...║..|....║..║.║   ");
            this.Controls.Add(console);
            this.Resize += Form1_Resize;
        }
        private void AppendCharacter(char character, int qty)
        {
            AppendCharacter(character, qty, Color.White);
        }
        private void AppendCharacter(char character, int qty, Color color)
        {
            AppendText(new string(character, qty), color);
        }
        private void AppendText(string text)
        {
            AppendText(text, Color.White);
        }
        private void AppendText(string text, Color color)
        {
            var originalColor = console.SelectionColor;
            console.SelectionColor = color;
            console.AppendText(text);
            console.SelectionColor = originalColor;
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            console.Size = this.ClientSize;
        }
    }
