    using System;
    using System.Drawing;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font("Consolas", 18f, FontStyle.Bold);
            richTextBox1.BackColor = Color.AliceBlue;
            string[] words =
            {
                "a",
                "b",
                "c",
                "d",
                "e",
                "f",
                "g."
            };
            Color[] colors =
            {
                Color.Aqua,
                Color.CadetBlue,
                Color.Cornsilk,
                Color.Gold,
                Color.HotPink,
                Color.Lavender,
                Color.Moccasin
            };
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                Color color = colors[i];
                {
                    richTextBox1.SelectionBackColor = color;
                    richTextBox1.AppendText(word);
                    richTextBox1.SelectionBackColor = Color.AliceBlue;
                    richTextBox1.AppendText(" ");
                }
            }
        }
    }
}
