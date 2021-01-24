    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace DataGridViewRowsToForm2_46306622
    {
        public partial class Form2 : Form
        {
            //Have a form constructor that accepts your GridViewRows as argument
            public Form2(List<DataGridViewRow> dgvc = null)
            {
                InitializeComponent();
                TextBox txtbx = new TextBox();
                txtbx.Location = new Point(5, 5);
                if (dgvc != null)
                {
                    //iterate through the rows and do what you want with them
                    foreach (DataGridViewRow item in dgvc)
                    {
                        txtbx.Text += item.Cells[0].Value + " / ";
                    }
                }
                this.Controls.Add(txtbx);
            }
        }
    }
