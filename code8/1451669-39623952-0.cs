        public partial class Form1 : Form
        {
          public Form1()
          {
            InitializeComponent();
            InitTextBox();
          }
          void InitTextBox()
          {
             AutoCompleteStringCollection textBoxCollection = new AutoCompleteStringCollection();
             textBoxCollection.Add("Bobby");
             textBoxCollection.Add("Billy");
             textBoxCollection.Add("Britney");
             textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
             textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
             textBox1.AutoCompleteCustomSource = textBoxCollection;
          }
        }
