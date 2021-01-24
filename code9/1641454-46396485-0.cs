    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    namespace CollectNames
    {
        public partial class MainForm : Form
        {
            private static readonly List<string> names = new List<string>();
            public MainForm()
            {
                InitializeComponent();
            }
            private void txtName_KeyUp(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    names.Add(txtName.Text);
                    txtName.Text = String.Empty;
                    e.Handled = true;
                }
            }
            private void btnSummary_Click(object sender, EventArgs e)
            {
                lstNames.Items.Clear();
                lstNames.Items.AddRange(names.Cast<object>().ToArray());
            }
        }
    }
