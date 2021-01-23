    public partial class Form1 : Form
    {
        public string Item { get; set; }
    }
    public partial class Form2 : Form
    {
        public string Item { get; set; }
        private Form1 parent;
        public Form2(Form1 parentForm) 
        {
            parent = parentForm;
            // example
            parent.Item = "myText";
        }
        // ... now you can access any public member in your parent form here
    }
    public partial class Form3 : Form
    {
        private Form1 greatParent;
        private Form2 parent;
        public Form3(Form1 greatParentForm, Form2 parentForm) 
        {
            greatParent = greatParentForm;
            parent = parentForm;
            // examples
            greatParent.Item = "myText";
            parent.Item = "myText";
        }
        // ... now you can access any public member in your parent and greatparent forms here
    }
