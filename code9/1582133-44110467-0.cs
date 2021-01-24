    private async void FindButton_Click(object sender, RoutedEventArgs e)
    {
        FindButton.Content = "Searching...";
        FindButton.IsEnabled = false;
        try
        {
            if (string.IsNullOrWhiteSpace(new TextRange(InputField.Document.ContentStart, InputField.Document.ContentEnd).Text))
            {
                OutputField.Document.Blocks.Clear();
                MessageBox.Show("Empty input");
            }
            else
            {
                string[] result;
                await Task.Run(() =>
                {
                    Parser nOb = new Parser(new TextRange(InputField.Document.ContentStart, InputField.Document.ContentEnd).Text);
                    result = nOb.find();
                });
                if (result == null || result.Length == 0)
                {
                    OutputField.Document.Blocks.Clear();
                    MessageBox.Show("Nothing found");
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < result.Length; i++)
                    {
                        sb.AppendLine(result[i]);
                    }
                    OutputField.Document.Blocks.Clear();
                    OutputField.Document.Blocks.Add(new Paragraph(new Run(sb.ToString())));
                    MessageBox.Show("Success");
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
        FindButton.Content = "Default";
        FindButton.IsEnabled = true;
    }
