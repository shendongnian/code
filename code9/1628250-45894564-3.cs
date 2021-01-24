    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            class MyClass : ICustomInterface
            {
            }
    
            public Form1()
            {
                InitializeComponent();
            }
    
            protected override void OnLoad(EventArgs e)
            {
                this.myComboBox1.Items.Add(new MyClass());
                this.myComboBox1.Items.Add(new MyClass());
    
                //Uncommenting following lines of code will produce exception.
                //Because class 'string' does not implement ICustomInterface.
    
                //this.myComboBox1.Items.Add("FFFFFF");
                //this.myComboBox1.Items.Add("AAAAAA");
    
                base.OnLoad(e);
            }
        }
    }
