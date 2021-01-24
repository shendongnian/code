    using System.Drawing;
    using System.Windows.Forms;
    
    namespace DataGridView_47478857
    {
        public partial class Form1 : Form
        {
    
            DataGridView dataGridView1 = new DataGridView();
            int yellowed = 0;
            int maxYellowed = 15;
            public Form1()
            {
                InitializeComponent();
                dataGridView1.Dock = DockStyle.Fill;
                dataGridView1.CellMouseUp += dataGridView1_CellMouseUp;
                dataGridView1.CellClick += dataGridView1_CellClick;
                this.Controls.Add(dataGridView1);
    
    
                dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
                //выделение только ячеек
    
                // создаём массив
    
                int[,] Array = new int[8, 10];
    
                byte numbers = 1;
    
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Array[i, j] = numbers;
                        numbers++;
                    }
                }
    
                dataGridView1.RowCount = 8;
                dataGridView1.ColumnCount = 10;
    
                // программно записываем массив и задаём стиль ячеек
    
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        dataGridView1.Columns[j].Width = 30;
                        dataGridView1.Rows[i].Height = 30;
                        dataGridView1.Rows[i].Cells[j].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView1.Rows[i].Cells[j].Style.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
                        dataGridView1.Rows[i].Cells[j].Value = Array[i, j].ToString();
                    }
                }
            }
    
            private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e) // выделение ячеек
            {
    
                for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
                {
                    if (dataGridView1.SelectedCells[i].Style.BackColor == Color.Yellow)
                    {
                        dataGridView1.SelectedCells[i].Style.BackColor = Color.White;
    
                    }
                    else
                    {
                        if (yellowed < maxYellowed)//only color code this cell if the yellow cell count has not been exceeded
                        {
                            dataGridView1.SelectedCells[i].Style.BackColor = Color.Yellow;
                            yellowed++;
                        }
                    }
                }
                dataGridView1.ClearSelection();
            }
    
            private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                yellowed = 0;
                foreach (DataGridViewRow currentRow in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell currentCell in currentRow.Cells)
                    {
                        if (currentCell.Style.BackColor == Color.Yellow)
                        {
                            yellowed++;
                        }
                    }
                }
            }
    
        }
    }
