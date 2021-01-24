            var rectangle = new Rectangle
                                {
                                    Fill = new SolidColorBrush(Colors.LightGray),
                                    Opacity = 0.5,
                                    Margin = new Thickness(0, -10, 0, 0),
                                    Height = 66
                                };
            MyGrid.SetColumn(rectangle, (int)maxLength - data.Length);
            MyGrid.SetColumnSpan(rectangle, data.Length);
