     public partial class FormAddUrls : Form
     {
         private readonly Form _parentForm;
         public FormAddUrls(MainForm parent)
         {
             _parentForm = parent;
             InitializeComponent();
         }
         private void btnAddUrls_Click(object sender, EventArgs e)
         {
             StringBuilder builder = new StringBuilder();
             builder.Append("{");
             foreach (string line in txtBoxURLsMass.Lines)
             {
                 //Helpers.returnMessage(line);
                 builder.Append(line + "|");
             }
             builder.Append("}");
             string finalOutput = "";
             if (builder.ToString().Contains("|}")) {
                 finalOutput = builder.ToString().Replace("|}", "}");
             }
             if(_parentForm != null)
                 _parentForm.txtBoxUrls.Text = finalOutput;
             this.Close();
         }
     }
