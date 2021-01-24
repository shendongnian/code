    using System;
    using System.Windows.Forms;
    using System.Collections.Generic;
    
    namespace PassParamsFromForm2ToForm1_45997869
    {
        public partial class Form2 : Form
        {
            public DataGridView returnGrid = new DataGridView();
            public List<DataGridViewRow> returnRows { get; set; }
            private DataGridView submittedGrid { get; set; }
    
    
            public Form2(DataGridView incomingGrid)
            {
                InitializeComponent();
                submittedGrid = incomingGrid;
                submittedGrid.Location = new System.Drawing.Point(this.Location.X + 5, this.Location.Y + 5);
                Controls.Add(submittedGrid);
                button1.Click += Button1_Click;
            }
    
    
            private void Button1_Click(object sender, EventArgs e)
            {
                returnGrid = submittedGrid;//if you want to return the grid
    
                //returning rows
                /*
                 * You'll need your own mechanism to differentiate between 
                 */
                bool rowIsModified = false;
                returnRows = new List<DataGridViewRow>();
                foreach (DataGridViewRow item in submittedGrid.Rows)
                {
                    if (item.Index % 2 != 0)
                    {
                        rowIsModified = true;
                    }
                    if (rowIsModified)
                    {
                        DataGridViewRow r = (DataGridViewRow)item.Clone();
                        for (int i = 0; i < item.Cells.Count; i++)
                        {
                            r.Cells[i].Value = item.Cells[i].Value;
                        }
                        returnRows.Add(r);
                    }
                }
                this.Close();
            }
        }
    }
