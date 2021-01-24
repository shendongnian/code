    public partial class Form1 : Form
        {
            private System.Windows.Forms.BindingSource form1BindingSource;
    
            public string BindedProp { get; set; } //Variable or property binded with TextBox
            public Form1()
            {
                InitializeComponent();
                this.form1BindingSource = new System.Windows.Forms.BindingSource(new System.ComponentModel.Container());
                this.form1BindingSource.DataSource = typeof(binding.Form1);
                this.textBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.form1BindingSource, "BindedProp", true));
                this.form1BindingSource.DataSource = this;
            }      
            //add a button control to assing value code event click
            private void btAssingValueProperty_Click(object sender, EventArgs e)
            {
                BindedProp = "Value assigned";
                form1BindingSource.ResetBindings(false);
    
            }
            //add a other button control to show value code event click
            private void btShowValueProperty_Click(object sender, EventArgs e)
            {
                MessageBox.Show(BindedProp);
            }
    
        }
