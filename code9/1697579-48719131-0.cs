    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.button13.Click += new System.EventHandler(this.button_Click);
                this.button14.Click += new System.EventHandler(this.button_Click);
                this.button15.Click += new System.EventHandler(this.button_Click);
                this.button16.Click += new System.EventHandler(this.button_Click);
            }
            private void button_Click(object sender, EventArgs e)
            {
                Button button = sender as Button;
                string name = button.Text;
            }
        }
    }
