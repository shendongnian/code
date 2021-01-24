    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace Formkeypress
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                KeyPreview = true;
            }
            protected override void OnKeyPress(KeyPressEventArgs e)
            {
                base.OnKeyPress(e);
                if (e.KeyChar == 'r') BackColor = Color.Red;
                if (e.KeyChar == 'b') BackColor = Color.Blue;
                if (e.KeyChar == 'g') BackColor = Color.Green;
            }
        }
