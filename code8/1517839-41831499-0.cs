    public class SermonReader : Form
    {
        public RichTextBoxEx rtbEx= new RichTextBoxEx();
        private string RTF = "";
        public SermonReader(string rtf)
        {
            RTF = rtf;
            Shown += new EventHandler(ehFormShown);
            FormBorderStyle = FormBorderStyle.None;
            TopLevel = false;
            
            Controls.Add(rtbEx);
            rtbEx.Dock = DockStyle.Fill;
        }
        private void ehFormShown(object sender, EventArgs e)
        {
            rtbEx.Rtf = RTF;
        }
    }
