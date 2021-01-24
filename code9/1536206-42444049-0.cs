    public class CustomDataGridView : DataGridView
    {
        private Button deleteButton = new Button();
        public CustomDataGridView()
        {
            this.Columns.Add("Column1", "Column1");
            this.Columns.Add("Column2", "Column2");
            this.Columns.Add("Column3", "Column3");
            this.CellMouseEnter += this_CellMouseEnter;
            deleteButton.Height = this.RowTemplate.Height - 1;
            deleteButton.Width = this.RowTemplate.Height - 1;
            deleteButton.Text = "";
            deleteButton.Visible = false;
            deleteButton.MouseClick += (s, e) =>
                MessageBox.Show("Delete Button Clicked!", "", MessageBoxButtons.OK);
            this.Controls.Add(deleteButton);
        }
        private void this_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                deleteButton.Visible = true;
                Rectangle rect = this.GetCellDisplayRectangle(2, e.RowIndex, true);
                deleteButton.Location = new Point(rect.Right - deleteButton.Width - 1, rect.Top);
            }
        }
    }
