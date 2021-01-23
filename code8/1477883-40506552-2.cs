    public partial class Form1 : Form
    { 
        // instance of class:
        MyClass _myClass = new MyClass();
        private void btn1_Click(object sender, EventArgs e)
        {
            _myClass.extractExtensions(textbox1.Text);
        }
    }
