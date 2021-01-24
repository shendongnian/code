    public partial class FormattingOverlay : UserControl
    {
        public FormattingOverlay(Form1 mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }
        private void btnBold_Click(object sender, EventArgs e)
        {
            RichTextBox rTxtBx = mainForm.rTxtBxSelectionTester;
            rTxtBx.SelectionFont = new Font(rTxtBx.Font, FontStyle.Bold);
            rTxtBx.SelectionStart = rTxtBx.SelectionStart + rTxtBx.SelectionLength;
            rTxtBx.SelectionLength = 0;
            rTxtBx.SelectionFont = rTxtBx.Font;
        }
    }
   
