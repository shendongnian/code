    for (int row = 0; row < 9; row++)
    {
      for (int col = 0; col < 9; col++)
      {
       num += 1;
       cell[row, col] = new TextBox();
       cell[row, col].Name = Convert.ToString(num);
       cell[row, col].MouseDown += new MouseEventHandler(cellMouseDown);
      }
    }
