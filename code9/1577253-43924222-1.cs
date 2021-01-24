    using System.Drawing;
    using System.Windows.Forms;
    
    namespace PassValuesBetweenForms_43923548
    {
        public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
            }
    
            //make a parametized constructor
            public Form2(string incomingFromForm1)
            {
                InitializeComponent();
                if (!string.IsNullOrEmpty(incomingFromForm1))
                {
                    MakeALabelWithThis(incomingFromForm1);
                }
            }
    
            private void MakeALabelWithThis(string incomingFromForm1)
            {
                Label lbl = new Label();
                lbl.Text = incomingFromForm1;
                lbl.Location = new Point(5,5);
                this.Controls.Add(lbl);
            }
        }
    }
