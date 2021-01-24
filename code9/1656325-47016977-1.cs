    HttpClient client = new HttpClient();
    private async void MyButton_Click(object sender, RoutedEventArgs e)
    {
        try {
            MyTextBlock.Text = "Waiting...";
            Uri webUri = new Uri("https://www.bing.com/");
            using (HttpResponseMessage response = await client.PostAsync(webUri, new ipartFormDataContent())) {
                MyTextBlock.Text = await response.Content.ReadAsStringAsync();
            }
        } catch (Exception exc) {
            MessageBox.Show(exc.ToString(), "Unhandled Exception");
        }
    }
