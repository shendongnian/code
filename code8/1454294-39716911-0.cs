    public partial class Form1: Form {
     public Form1()
     {
        InitializeComponent();
     }
     public string deva = "123";
     //button
     private void button8_Click(object sender, EventArgs e)
     {
        deva = "456";
     }
     private void button9_Click(object sender, EventArgs e)
     {
        Other ks = new Other(this);
        ks.test_me();
    }
    }
