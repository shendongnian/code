    int row = 2; 
    int column = 0;
    for (int i = 0; i < 195; i++)
    {
         Canvas c = new Canvas();
    
         gridMain.Children.Add(c);
    
         Grid.SetRow(c, row);
         Grid.SetColumn(c, column);  
         if (column == 14)
         {
             column = 0;
             row++;
         }
         else
         {
             column++;
         }
    }
