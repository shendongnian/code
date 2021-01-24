    using System;
    using System.Windows.Forms;
    
    namespace PassParamsFromForm2ToForm1_45997869
    {
        public partial class Form2 : Form
        {
            public string returnValue;
            private string submittedString { get; set; }
            public Form2(string incomingString)
            {
                InitializeComponent();
                submittedString = incomingString;
                button1.Click += Button1_Click;
            }
    
            private void Button1_Click(object sender, EventArgs e)
            {
                returnValue = "I'd rather show you my value instead of yours(" + submittedString + ")...";
                this.Close();
            }
        }
    }
