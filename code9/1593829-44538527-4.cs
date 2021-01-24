    private async void Handle_Clicked (object sender, System.EventArgs e)
    {
        try
        {
            using (var client = new HttpClient ()) {
                var response = await client.GetAsync ($"http://xxxxxxxxxxxx.aspx?title={title_entry.Text}&details={details_entry.Text}");
    
                // TODO do something with response
            }
        }
        catch(Exception ex)
        {
            // Handle error
        }
    }
