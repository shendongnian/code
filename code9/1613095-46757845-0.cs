     if (this.Padding != default(Thickness))
                    {
                        Device.BeginInvokeOnMainThread(() =>
                          {
                               
                              if (Parent is Grid)
                              {
                                  var parentAsGrid = Parent as Grid;
                                  var index = parentAsGrid.Children.IndexOf(this);
                                  parentAsGrid.Children.Remove(this);
                                  Grid marginGrid = new Grid() { BackgroundColor = this.BackgroundColor,  HorizontalOptions = this.HorizontalOptions, VerticalOptions = this.VerticalOptions };
    
    
                                  var lbl = new Label() { Text = this.Text, TextColor = this.TextColor, BackgroundColor = this.BackgroundColor, HorizontalOptions = this.HorizontalOptions, VerticalOptions = this.VerticalOptions, FontSize = this.FontSize };
                                  lbl.Margin = this.Padding;
                                  if (!parentAsGrid.Children.Contains(this))
                                  {
                                      marginGrid.Children.Add(lbl);
                                      parentAsGrid.Children.Insert(index, marginGrid);
                                  }
    
                              }
                              if (Parent is StackLayout)
                              {
                                  var parentAsGrid = Parent as StackLayout;
                                  var index = parentAsGrid.Children.IndexOf(this);
                                  parentAsGrid.Children.Remove(this);
                                  Grid marginGrid = new Grid() { BackgroundColor = this.BackgroundColor,   HorizontalOptions = this.HorizontalOptions, VerticalOptions = this.VerticalOptions };
    
    
                                  var lbl = new Label() { Text = this.Text, TextColor = this.TextColor, BackgroundColor = this.BackgroundColor, HorizontalOptions = this.HorizontalOptions, VerticalOptions = this.VerticalOptions, FontSize = this.FontSize };
                                  lbl.Margin = this.Padding;
                                  if (!parentAsGrid.Children.Contains(this))
                                  {
                                      marginGrid.Children.Add(lbl);
                                      parentAsGrid.Children.Insert(index, marginGrid);
                                  }
    
                              }
                            
    
    
                          });
