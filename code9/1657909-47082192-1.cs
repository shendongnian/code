    using System.ComponentModel;
    using System.Windows.Forms;
    
    namespace Datagridview_47080892
    {
        public partial class Form1 : Form
        {
            DataGridView dgv = new DataGridView();
            BindingList<BindedItem> dgvlist = new BindingList<BindedItem>();
            BindingList<comboItem> comboList = new BindingList<comboItem>();
    
            public Form1()
            {
                InitializeComponent();
                InitDGV();
                AddData();
            }
    
            private void AddData()
            {
                for (int i = 0; i < 5; i++)
                {
                    dgvlist.Add(new BindedItem
                    {
                        prop1 = $"prop1value{i}",
                        prop2 = $"prop2value{i}",
                        prop3 = $"prop3value{i}",
                        prop4 = $"{i}"
                    });
                }
    
                comboList.Add(new comboItem { showThis = "Make a selection", butTheValueIs = "0" });
                comboList.Add(new comboItem { showThis = "Option 1", butTheValueIs = "1" });
                comboList.Add(new comboItem { showThis = "Option 2", butTheValueIs = "2" });
                comboList.Add(new comboItem { showThis = "Option 3", butTheValueIs = "3" });
                comboList.Add(new comboItem { showThis = "Option 4", butTheValueIs = "4" });
                comboList.Add(new comboItem { showThis = "Option 5", butTheValueIs = "5" });
                comboList.Add(new comboItem { showThis = "Option 6", butTheValueIs = "6" });
                comboList.Add(new comboItem { showThis = "Option 7", butTheValueIs = "7" });
                comboList.Add(new comboItem { showThis = "Option 8", butTheValueIs = "8" });
    
            }
    
            private void InitDGV()
            {
                //dgv.Location = new Point(5, 5);
                dgv.Dock = DockStyle.Top;
                this.Controls.Add(dgv);
                dgv.AutoGenerateColumns = false;
                dgv.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()));
                dgv.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()));
                dgv.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()));
    
                DataGridViewComboBoxColumn cbcol = new DataGridViewComboBoxColumn();
                cbcol.DataSource = comboList;
                cbcol.DisplayMember = "showThis";
                cbcol.ValueMember = "butTheValueIs";
                dgv.Columns.Add(cbcol);
    
                dgv.Columns[0].DataPropertyName = "prop1";
                dgv.Columns[1].DataPropertyName = "prop2";
                dgv.Columns[2].DataPropertyName = "prop3";
                dgv.Columns[3].DataPropertyName = "prop4";
    
                dgv.DataSource = dgvlist;
            }
        }
    
    
        public class BindedItem
        {
            public string prop1 { get; set; }
            public string prop2 { get; set; }
            public string prop3 { get; set; }
            public string prop4 { get; set; }
        }
        public class comboItem
        {
            public string showThis { get; set; }
            public string butTheValueIs { get; set; }
        }
    }
