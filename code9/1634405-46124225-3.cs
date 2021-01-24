    private async Task<bool> IsUserAvaliable(string handle)
    {
        while (true)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string content = await client.GetStringAsync("http://url.com/script.php?user=" + handle);
                    return content.Contains("No users found");
                }
                catch (WebException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
