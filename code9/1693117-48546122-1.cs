    private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.DataGridCell dataGridCell = null;
                  
            dataGridCell = LoadMapGrid.GetCell(1,1);
            string A =dataGridCell.ToString(); //Return : System.Windows.Controls.DataGridCell: "MyValue"
            Char delimiter = ' ';
            string[] str = new string[1];
            str = A.Split(delimiter);
            System.Windows.MessageBox.Show(str[1]);
           
        }
