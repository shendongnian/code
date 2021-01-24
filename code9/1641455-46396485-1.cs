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
                // Usually we set these event handlers using the 'Properties' tab for each specified control.
                // => Click on the control once then press F4 so that 'Properties' tab will appear.
                // Then these event subscriptions will be generated into MainForm.Designer.cs file.
                // They are here just for clarity.
                txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(txtName_KeyUp);
                btnSummary.Click += new System.EventHandler(btnSummary_Click);
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
