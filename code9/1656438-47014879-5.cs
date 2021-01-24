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
            this.Controls.Add(console);
            this.Resize += Form1_Resize;
            DrawDiagram();
        }
        private void DrawDiagram()
        {
            WriteLine("The djinni speaks. \"I am in your debt. I will grant one wish!\"--More--\n");
            Dot(7);
            Diamond(2);
            WriteLine("....╔═══════╗..╔═╗");
            Dot(8);
            Diamond(2);
            WriteLine("...║..|....║..║.╠══════╦══════╗");
            Dot(9);
            Diamond(2);
            Write("..║.|.....║..║.║      ║.");
            Write('&', Color.DarkRed);
            Dot(4);
            WriteLine("║");
        }
        private void Dot(int qty)
        {
            Write('.', qty);
        }
        private void WriteLine(string text)
        {
            Write($"{text}\n");
        }
        private void Diamond(int qty)
        {
            Write('♦', qty, Color.Blue);
        }
        private void Write(char character, Color color)
        {
            Write(character, 1, color);
        }
        private void Write(char character, int qty)
        {
            Write(character, qty, Color.White);
        }
        private void Write(char character, int qty, Color color)
        {
            Write(new string(character, qty), color);
        }
        private void Write(string text)
        {
            Write(text, Color.White);
        }
        private void Write(string text, Color color)
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
