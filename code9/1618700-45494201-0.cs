    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace DatagridView_45493968
    {
        public partial class Form1 : Form
        {
            BindingList<dgventry> dgvItemList = new BindingList<dgventry>();
            DataGridView dgv = new DataGridView();
            TextBox txtb = new TextBox();
            public Form1()
            {
                InitializeComponent();
                //Nothing in the wysiwyg form, everything in codeBehind
                MakeTheGrid();
                MakeTheTextBox();
                /**/
    
                //add some records to the Grid
                dgvItemList.Add(new dgventry { col1 = "1", col2 = "11", col3 = "111" });
                dgvItemList.Add(new dgventry { col1 = "2", col2 = "22", col3 = "222" });
                dgvItemList.Add(new dgventry { col1 = "3", col2 = "22", col3 = "333" });
    
                
            }
    
            private void Dgv_SelectionChanged(object sender, EventArgs e)
            {
                DataGridView theGrid = sender as DataGridView;
    
                //if the grid aint null, and the grid has rows, and something is selected
                if (theGrid != null && theGrid.RowCount > 0 && theGrid.SelectedCells.Count > 0)
                {
                    //get the `OwningRow` of the selected Cells and do your thing!
                    txtb.Text = (string)theGrid.SelectedCells[0].OwningRow.Cells[0].FormattedValue;
                }
            }
    
            private void MakeTheTextBox()
            {
                txtb.Location = new Point(dgv.Location.X, dgv.Location.Y + dgv.Height + 5);
                this.Controls.Add(txtb);
            }
    
            private void MakeTheGrid()
            {
                dgv.Location = new Point(this.Location.X + 5, this.Location.Y + 5);
                dgv.DataSource = dgvItemList;
                this.Controls.Add(dgv);
                dgv.SelectionChanged += Dgv_SelectionChanged;
            }
        }
    
        public class dgventry
        {
            public string col1 { get; set; }
            public string col2 { get; set; }
            public string col3 { get; set; }
        }
    }
