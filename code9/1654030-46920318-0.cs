    using System;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace BindingToDataTable_46914296
    {
        
    
        public partial class Form1 : Form
        {
            ComboBox combob = new ComboBox();
            ComboBox combobFail = new ComboBox();
            TextBox txtbx = new TextBox();
            public Form1()
            {
                InitializeComponent();
                InitComboBox();
                InitComboBoxFail();
                InitTxtBx();
            }
    
            private void InitTxtBx()
            {
                txtbx.Location = new Point(5, 30);
                txtbx.Width = this.Width - 10;
                this.Controls.Add(txtbx);
            }
    
            /// <summary>
            /// This version works, the proper selected value shows up in the textbox
            /// </summary>
            private void InitComboBox()
            {
                combob.Location = new Point(5,5);
                this.Controls.Add(combob);
    
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("Col1", typeof(string)));
                dt.Columns.Add(new DataColumn("Col2", typeof(string)));
                dt.Columns.Add(new DataColumn("Col3", typeof(string)));
                dt.Columns.Add(new DataColumn("Col4", typeof(Int32)));
                dt.Rows.Add("blah1", "bleh", "bloh", 1);
                dt.Rows.Add("blah2", "bleh", "bloh", 2);
                dt.Rows.Add("blah3", "bleh", "bloh", 3);
                dt.Rows.Add("blah4", "bleh", "bloh", 4);
                combob.DataSource = dt;
                combob.DisplayMember = "Col1";
                combob.ValueMember = "Col4";
    
                combob.SelectedValueChanged += Combob_SelectedValueChanged;
            }
    
    
            /// <summary>
            /// This version DOES NOT work, a DataRowView item appears in the textbox when the selection changes
            /// </summary>
            private void InitComboBoxFail()
            {
                combobFail.Location = new Point(combob.Location.X + combob.Width + 5, 5);
                this.Controls.Add(combobFail);
    
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("Col1", typeof(string)));
                dt.Columns.Add(new DataColumn("Col2", typeof(string)));
                dt.Columns.Add(new DataColumn("Col3", typeof(string)));
                dt.Columns.Add(new DataColumn("Col4", typeof(Int32)));
                dt.Rows.Add("blah1", "bleh", "bloh", 1);
                dt.Rows.Add("blah2", "bleh", "bloh", 2);
                dt.Rows.Add("blah3", "bleh", "bloh", 3);
                dt.Rows.Add("blah4", "bleh", "bloh", 4);
                combobFail.DataSource = dt;
                combobFail.DisplayMember = "Col1";
                //only difference is I am not binding ValueMember
    
                combobFail.SelectedValueChanged += Combob_SelectedValueChanged;
            }
    
            private void Combob_SelectedValueChanged(object sender, EventArgs e)
            {
                txtbx.Text = ((ComboBox)sender).SelectedValue.ToString();
            }
        }
    }
