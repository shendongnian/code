    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace DataGridViewRowsToForm2_46306622
    {
        public partial class Form1 : Form
        {
    
            DataGridView dgv1 = new DataGridView();
            BindingList<dgventry> dgv1Data = new BindingList<dgventry>();
            Button btn = new Button();
    
            public Form1()
            {
                InitializeComponent();
                InitializeGrid();
                AddButton();
                AddData();
            }
    
            private void AddButton()
            {
                btn.Location = new Point(5, dgv1.Location.Y + dgv1.Height + 5);
                btn.Text = "Click to pass rows";
                btn.Click += Btn_Click;
                this.Controls.Add(btn);
            }
    
            private void Btn_Click(object sender, EventArgs e)
            {
                List<DataGridViewRow> listofrows = new List<DataGridViewRow>();
                foreach (DataGridViewRow item in dgv1.Rows)
                {
                    DataGridViewRow r = (DataGridViewRow)item.Clone();
                    for (int i = 0; i < item.Cells.Count; i++)
                    {
                        r.Cells[i].Value = item.Cells[i].Value;
                    }
                    listofrows.Add(r);
                }
                Form2 f2 = new Form2(listofrows);
                f2.Show();
            }
    
            private void AddData()
            {
                for (int i = 0; i < 5; i++)
                {
                    dgv1Data.Add(new dgventry
                    {
                        col1 = "row " + i,
                        col2 = i.ToString(),
                        col3 = i.ToString()
                    });
                }
    
            }
    
            private void InitializeGrid()
            {
                dgv1.Location = new Point(5, 5);
                dgv1.DataSource = dgv1Data;
                this.Controls.Add(dgv1);
            }
        }
    
        public class dgventry
        {
            public string col1 { get; set; }
            public string col2 { get; set; }
            public string col3 { get; set; }
        }
    }
