    TextBlock txtblck = new TextBlock();
    txtblck.Inlines.Add(new InlineUIContainer
                        {
                            Child = new TextBlock
                                    {
                                        Text = "abc",
                                        Width = 100
                                    }
                        });    
    txtblck.Inlines.Add(new InlineUIContainer
                        {
                            Child = new TextBlock
                                    {
                                        Text = "def",
                                        Width = 100
                                    }
                        });
