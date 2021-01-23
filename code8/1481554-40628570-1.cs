    private async void myObject_HandleEvent(object sender, EventArgs e)
    {
        string text = await GetStringFromDataBaseAsync();
    }
    
    private Task<string> GetStringFromDataBaseAsync()
    {
        string result = "";
        // Obtain value and store it in value
        return result;
    }
