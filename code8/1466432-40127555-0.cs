		public partial class Form2 : Form
		 {
			 public Form2()
			 {
				 InitializeComponent();
			 }
			 public string GetSetControlValue
			 {
				 get { return this.txtControl.Text; }
				 set { this.txtControl.Text = value; }
			 }
		 }
		// In Form1 you can access the control like this:
		private void Button1_Click(object sender, EventArgs e)
		{
			 Form2 form2= new Form2();
			 form2.GetSetControlValue = "Hello, world.";
			 form2.ShowDialog();
		}
