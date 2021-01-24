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
            console.Font = new Font("Consolas", 12);
            console.Text = "The djinni speaks. \"I am in your debt. I will grant one wish!\"--More--\n\n";
            Dot(7);
            Diamond(2);
            AppendLine("....╔═══════╗..╔═╗");
            Dot(8);
            Diamond(2);
            AppendLine("...║..|....║..║.╠══════╦══════╗");
            Dot(9);
            Diamond(2);
            AppendText("..║.|.....║..║.║      ║.");
            AppendCharacter('&', Color.DarkRed);
            Dot(4);
            AppendLine("║");
            this.Controls.Add(console);
            this.Resize += Form1_Resize;
        }
        private void Dot(int qty)
        {
            AppendCharacter('.', qty);
        }
        private void AppendLine(string text)
        {
            AppendText($"{text}\n");
        }
        private void Diamond(int qty)
        {
            AppendCharacter('♦', qty, Color.Blue);
        }
        private void AppendCharacter(char character, int qty)
        {
            AppendCharacter(character, qty, Color.White);
        }
        private void AppendCharacter(char character, Color color)
        {
            AppendCharacter(character, 1, color);
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
