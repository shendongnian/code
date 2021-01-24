    public partial class UserInputForm : Form
    {
        public new  Form1 Parent { get; set; }//If you want to replace Parent prop use new keyword otherwise rename Parent prop 
        public UserInputForm(Form1 parent)
        {
            Parent = parent; 
            InitializeComponent();
        } 
        public void btnAdd_Click(object sender, EventArgs e)
        { 
            Parent.SetData(txtName.Text); //Error on line
        } 
    }
