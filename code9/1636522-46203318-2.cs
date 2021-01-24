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
        var json = JsonConvert.SerializeObject(model);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        var path = "api/api/Account/PasswordReset";
        return client.PostAsync(path, content); //the Address is correct
    }
