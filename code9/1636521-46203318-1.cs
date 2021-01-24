    private async void BtnSubmitClicked(object sender, EventArgs eventArgs) {
        HttpResponseMessage response = await ResetPasswordAsync();
        App.Log(string.Format("Status Code: {0}", response.StatusCode));
    }
    public Task<HttpResponseMessage> ResetPasswordAsync() {
        var model = new ForgotPassword() {
            Email = Email.Text
        };
        var client = new HttpClient();
        client.BaseAddress = new Uri("http://192.168.79.119:10000");
        var content = new StringContent(JsonConvert.SerializeObject(model), 
                                        System.Text.Encoding.UTF8, "application/json");
        return client.PostAsync("api/api/Account/PasswordReset", content); //the Address is correct
    }
