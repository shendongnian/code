    txtInformation.SetBinding(TextBlock.TextProperty,
                                  new Binding()
                                  {
                                      Mode = BindingMode.OneWay,
                                      Source = ViewModel.Item,
                                      Path = new 
                                      PropertyPath("Information"),
                                      TargetNullValue = "No information found"
                                  });
