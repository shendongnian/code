    private async void FindButton_Click(object sender, RoutedEventArgs e)
    {
        FindButton.Content = "Searching...";
        FindButton.IsEnabled = false;
        await Task.Delay(1);
        try
        {
            string parsed = string.Empty;
            if (string.IsNullOrWhiteSpace(new TextRange(InputField.Document.ContentStart, InputField.Document.ContentEnd).Text)) ;
            {
                OutputField.Document.Blocks.Clear();
                MessageBox.Show("Empty input");
            }
                    else
                    {
                Parser nOb = new Parser(new TextRange(InputField.Document.ContentStart, InputField.Document.ContentEnd).Text);
                string[] result = nOb.findAddresses();
                if (result.Length == 0)
                {
                    OutputField.Document.Blocks.Clear();
                    MessageBox.Show("Nothing found");
                }
                else
                {
                    for (int i = 0; i < result.Length; i++)
                    {
                        parsed += result[i] + Environment.NewLine;
                    }
                    OutputField.Document.Blocks.Clear();
                    OutputField.Document.Blocks.Add(new Paragraph(new Run(parsed)));
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
