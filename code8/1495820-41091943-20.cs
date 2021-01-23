    public partial class Form1 : Form
    {
        private System.Windows.Forms.TextBox textBox1;
        private TextExtractor _textExtractor;
        public Form1()
        {
            InitializeComponent();
            _textExtractor = new TextExtractor();
    
            textBox1 = new System.Windows.Forms.TextBox();
            textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            textBox1.AllowDrop = true;
            textBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            textBox1.DragOver += new System.Windows.Forms.DragEventHandler(this.textBox1_DragOver);
            Controls.Add(this.textBox1);
            Name = "Drag/Drop any file on to the TextBox";
            ClientSize = new System.Drawing.Size(867, 523);
        }
    
        private void textBox1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
    
        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length != 0)
            {
                TextExtractionResult textExtractionResult = _textExtractor.Extract(files[0]);
                textBox1.Text = textExtractionResult.Text;
            }
        }
    }
