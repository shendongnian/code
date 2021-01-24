        using System;
    using System.Drawing;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            box.AppendText("[" + DateTime.Now.ToShortTimeString() + "]", Color.Red);
            box.AppendText(" ");
            box.AppendText("GREEN TEXT", Color.Green);
            box.AppendText(": ");
            box.AppendText("BLUE TEXT", Color.Blue);
            box.AppendText(Environment.NewLine);
        }
    }
    }
