        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var header = new DataGridColumnHeader() { Content = e.PropertyName }; ;
            e.Column.Header = header;
            header.MouseEnter += Header_MouseEnter;
            header.MouseLeave += Header_MouseLeave;
                
        }
        private void Header_MouseLeave(object sender, MouseEventArgs e)
        {
            ((DataGridColumnHeader)sender).Column.CellStyle = null;
        }
        private void Header_MouseEnter(object sender, MouseEventArgs e)
        {
            ((DataGridColumnHeader)sender).Column.CellStyle = TryFindResource("cellStyle") as Style;
        }
