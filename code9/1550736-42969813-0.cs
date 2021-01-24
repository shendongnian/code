    public class MyForm
    {
        private MyTextBox _textBox;
        ....
        public MyForm()
        {
            InitializeComponent();
            _textBox = new MyTextBox();
            _textBox.TextChanged += (s, e) => {...};
            ....
        }
    }
