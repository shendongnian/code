    public class Form1: Form
    { 
        private List<Button> myButtons = new List<Button>();
        public Form1()
        {
            InitializeComponent();
            foreach(Button btn in this.Controls.OfType<Button>()
                myButtons.Add(btn);
        }
    }
