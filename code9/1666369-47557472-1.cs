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
                this.Controls.Add(dgv1);//add the DGV to the form
                dgv1.DataSource = dgv1data;//bind our data to it
                dgv1.Dock = DockStyle.Left;//place the DGV somewhere on the form
    
                this.Controls.Add(dgv2);//add the DGV to the form
                dgv2.DataSource = dgv2data;//bind out data to it
                dgv2.Dock = DockStyle.Right;//place the DGV somewhere on the form
    
                this.Controls.Add(btn);//add the Button to the form
                btn.Dock = DockStyle.Bottom;//place the Button somewhere on the form
                btn.Click += Btn_Click;//give the Button a event handler
            }
    
    
    
    
            private void Btn_Click(object sender, EventArgs e)
            {
                List<int> doneIndices = new List<int>();//this will keep track of the row indices we have dealt with
    
                if (dgv1.SelectedCells.Count > 0)//if something is selected
                {
                    foreach (DataGridViewCell item in dgv1.SelectedCells)//loop through the selected cells
                    {
                        if (!doneIndices.Contains(item.OwningRow.Index))//if this cell does not belong to a row index we already processed
                        {
                            //we haven't done this row yet
                            dgv2data.Add((dgventry)item.OwningRow.DataBoundItem);//add the DataBoundItem to the other DGV data
                            doneIndices.Add(item.OwningRow.Index);//put the current row index in our tracking list
                        }
                        else
                        {
                            //we have done this row already, move on to the next one
                            continue;
                        }
                    }
                }
                
                //remove all the duplicate entries
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
