    public async Task Login(string username, string password)
    {
        //TODO: Do parameter check for username and password
        try
        {
            var response = await GetAsync(new Uri(Constants.loginEndpoint + username + "/" + password + "/"));
            if (response.IsSuccessStatusCode)
            {
                // Process the positive response here
            }
            else
            {
                var alertDialog = new AlertDialog.Builder(context)
                   .SetTitle("Failure")
                   .SetMessage("Request failed.")
                   .SetPositiveButton("OK", (senderAlert, args) =>
                       {
                           Finish();
                       })
                   .Create();
    
                alertDialog.Show();
            }
        }
        catch (Exception ex)
        {
            var alertDialog = new AlertDialog.Builder(context)
                .SetTitle("Failure")
                .SetMessage("Something went wrong (" + ex.Message +")")
                .SetPositiveButton("OK", (senderAlert, args) =>
                    {
                       Finish();
                    })
                .Create();
    
            alertDialog.Show();
        }
    }
