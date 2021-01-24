    txtInformation.SetBinding(TextBlock.TextProperty,
                                  new Binding()
                                  {
                                      Mode = BindingMode.OneWay,
                                      Source = ViewModel,
                                      Path = new 
                                      PropertyPath("Item.Information"),
                                      TargetNullValue = "No information found"
                                  });
