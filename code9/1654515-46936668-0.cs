    using System.Drawing;
    using System.Windows.Forms;
    
    namespace UnregisterEvent_46936409
    {
        
        public partial class Form1 : Form
        {
            Button btn1 = new Button();
            TextBox txtbx = new TextBox();
            public Form1()
            {
                InitializeComponent();
                btn1.Location = new Point(5,5);
                txtbx.Location = new Point(5, btn1.Location.Y + btn1.Height + 2);
                this.Controls.Add(btn1);
                this.Controls.Add(txtbx);
                btn1.Click += (sender2, context2) => DoSomethingCool("put me in there", "yahoo");//subscribe to event handler
            }
    
            private void DoSomethingCool(string incoming1, string incoming2)
            {
                txtbx.Text = incoming1 + incoming2;
                btn1.Click -= (Sender2, context2) => DoSomethingCool("shouldnt do anything","blah blah");//unsubscribe from the event
            }
        }
    }
