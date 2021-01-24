    namespace WindowsFormsApp3
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void AnswerButton_Click(object sender, EventArgs e)
        {
            Sums test = new Sums();
    
            int res = test.multiplynumbers(5, 2);
            answerText.Text = res.ToString();
    
        }
    }
    }
