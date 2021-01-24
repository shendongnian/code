    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    namespace MoveDataBetweenDataGridView_47454256
    {
        public partial class Form1 : Form
        {
            static BindingList<dgventry> dgv1data = new BindingList<dgventry>();
            static BindingList<dgventry> dgv2data = new BindingList<dgventry>();
            DataGridView dgv1 = new DataGridView();
            DataGridView dgv2 = new DataGridView();
            Button btn = new Button();
    
            public Form1()
            {
                InitializeComponent();
    
                InitOurStuff();
                for (int i = 0; i < 10; i++)
                {
                    dgv1data.Add(new MoveDataBetweenDataGridView_47454256.dgventry
                    {
                        col1 = $"col1_{i}", col2 = $"col2_{i}", col3 = $"col3_{i}"});
                    }
                
            }
    
            private void InitOurStuff()
            {
                this.Controls.Add(dgv1);
                dgv1.DataSource = dgv1data;
                dgv1.Dock = DockStyle.Left;
                this.Controls.Add(dgv2);
                dgv2.DataSource = dgv2data;
                dgv2.Dock = DockStyle.Right;
                this.Controls.Add(btn);
                btn.Dock = DockStyle.Bottom;
                btn.Click += Btn_Click;
            }
    
            private void Btn_Click(object sender, EventArgs e)
            {
                List<int> doneIndices = new List<int>();
                if (dgv1.SelectedCells.Count > 0)
                {
                    foreach (DataGridViewCell item in dgv1.SelectedCells)
                    {
                        if (!doneIndices.Contains(item.OwningRow.Index))
                        {
                            //we haven't done this row yet
                            dgv2data.Add((dgventry)item.OwningRow.DataBoundItem);
                            doneIndices.Add(item.OwningRow.Index);
                        }
                        else
                        {
                            //we have done this row already, move on to the next one
                            continue;
                        }
                    }
                }
                dgv2.DataSource = dgv2data;
                foreach (dgventry item in dgv2data)
                {
                    dgv1data.Remove(item);
                }
            }
        }
    
    
    
        public class dgventry
        {
            public string col1 { get; set; }
            public string col2 { get; set; }
            public string col3 { get; set; }
    
        }
    }
