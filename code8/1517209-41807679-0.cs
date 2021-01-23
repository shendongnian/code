        public class Form1 : System.Windows.Forms.Form
        {
            //Controls.
            private TextBox txtBox = new TextBox();
            private Button btnAdd = new Button();
            private ListBox lstBox = new ListBox();
            private CheckBox chkBox = new CheckBox();
            private Label lblCount = new Label();
        
            private void Form1_Load(object sender, EventArgs e) 
            {
               //Add controls to the form.
               this.Controls.Add(btnAdd);
               this.Controls.Add(txtBox);
               this.Controls.Add(lstBox);
               this.Controls.Add(chkBox);
               this.Controls.Add(lblCount);
            }
        }
