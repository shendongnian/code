    GridLengthConverter gridLengthConverter = new GridLengthConverter();
                RowDefinition row1 = new RowDefinition();
                row1.Height = (GridLength)gridLengthConverter.ConvertFrom("*");
                RowDefinition row2 = new RowDefinition();
                row2.Height = (GridLength)gridLengthConverter.ConvertFrom("*");
                RowDefinition row3 = new RowDefinition();
                row3.Height = (GridLength)gridLengthConverter.ConvertFrom("*");
                RowDefinition row4 = new RowDefinition();
                row4.Height = (GridLength)gridLengthConverter.ConvertFrom("*");
                mainPanel.RowDefinitions.Add(row1);
                mainPanel.RowDefinitions.Add(row2);
                mainPanel.RowDefinitions.Add(row3);
                mainPanel.RowDefinitions.Add(row4);
                ColumnDefinition col1 = new ColumnDefinition();
                col1.Width = (GridLength)gridLengthConverter.ConvertFrom("*");
                ColumnDefinition col2 = new ColumnDefinition();
                col2.Width = (GridLength)gridLengthConverter.ConvertFrom("*");
                ColumnDefinition col3 = new ColumnDefinition();
                col3.Width = (GridLength)gridLengthConverter.ConvertFrom("*");
                ColumnDefinition col4 = new ColumnDefinition();
                col4.Width = (GridLength)gridLengthConverter.ConvertFrom("*");
                mainPanel.ColumnDefinitions.Add(col1);
                mainPanel.ColumnDefinitions.Add(col2);
                mainPanel.ColumnDefinitions.Add(col3);
                mainPanel.ColumnDefinitions.Add(col4);
                int row = 0;
                int col = 0;
                foreach (var buttonName in List)
                {
                    if(row<=4)
                    {
                        if (col <= 4)
                        {
                            Button newButton = new Button()
                            {
                                Content = buttonName.Name,
                               
                            };
                            Grid.SetRow(newButton, row);
                            Grid.SetColumn(newButton, col);
                            col++;
                            this.mainPanel.Children.Add(newButton);
                        }
                        else
                        {
                            row++;
                            col = 0;
                        }
                    }
                    
                }
