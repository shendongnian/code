    private void button1_Click_1(object sender, EventArgs e)
    {
        int numberOfRows = 2;
        int numberOfColumns = 5;
        for (int row = 0; i < numberOfRows; i++)
        {
            for (int col = 1; j < numberOfColumns; j++)
            {
                index = row * numberOfColumns + col;
                var checkbox = new CheckBox();
                c[index].Location = new Point(5 * j, 20 * i);
                this.Controls.Add(checkbox);
            }
        }
    }
