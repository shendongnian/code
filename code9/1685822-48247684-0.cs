        for (int i = 0; i < dimensions; i++)
            {
                for (int j = 0; j < dimensions; j++)
                {
                    await Dispatcher.RunIdleAsync(o =>
                    {
                        var cell = new ImageCell()
                        {
                            Row = i,
                            Column = j
                        };
                        Grid.SetRow(cell, i);
                        Grid.SetColumn(cell, j);
                        Grid.Children.Add(cell);
                    });
                }
            }
