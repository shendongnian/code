    private void button1_Click_1(object sender, EventArgs e)
    {
        int numberOfRows = 2;
        int numberOfColumns = 5;
        for (int row = 0; row < numberOfRows; row++)
        {
            for (int col = 0; col < numberOfColumns; col++)
            {
                int index = row * numberOfColumns + col;
                var checkbox = new CheckBox();
                c[index].Location = new Point(20 * col, 20 * row);
                this.Controls.Add(checkbox);
            }
        }
    }
