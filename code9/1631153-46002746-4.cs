    using System;
    using System.Windows.Forms;
    using System.ComponentModel;
    
    namespace PassParamsFromForm2ToForm1_45997869
    {
        public partial class Form1 : Form
        {
            BindingList<gridentry> gridList = new BindingList<gridentry>();
            DataGridView dgv = new DataGridView();
            DataGridView gridViewForTheReturnedRows;
            public Form1()
            {
                InitializeComponent();
                initializeGrid();
                addDataToGridSource("name1");
                addDataToGridSource("name2");
                addDataToGridSource("name3");
                addDataToGridSource("name4");
                button1.Click += Button1_Click;
            }
    
            private void addDataToGridSource(string incomingString)
            {
                gridList.Add(new gridentry { col1 = incomingString, col2 = incomingString + "in col2", col3 = incomingString + "in col3" });
            }
    
            private void initializeGrid()
            {
                dgv.Location = new System.Drawing.Point(this.Location.X + 5, this.Location.Y + 5);
                this.Controls.Add(dgv);
                dgv.AutoGenerateColumns = true;
                dgv.DataSource = gridList;
            }
    
            private void Button1_Click(object sender, EventArgs e)
            {
                Form2 f2 = new Form2(dgv);
                f2.ShowDialog();
    
                if (f2.returnRows != null && f2.returnRows.Count > 0)
                {
                    gridViewForTheReturnedRows = new DataGridView();
                    gridViewForTheReturnedRows.ColumnCount = f2.returnRows[0].Cells.Count;
                    gridViewForTheReturnedRows.Rows.InsertRange(0, f2.returnRows.ToArray());
    
                    gridViewForTheReturnedRows.Location = new System.Drawing.Point(10, dgv.Location.Y + dgv.Height + 5);
                    this.Controls.Add(gridViewForTheReturnedRows);
                }
            }
        }
    
        public class gridentry
        {
            public string col1 { get; set; }
            public string col2 { get; set; }
            public string col3 { get; set; }
        }
    }
