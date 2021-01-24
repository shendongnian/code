    public async Task getOfficerToken(dynamic client) 
    {
        var result = await client.officers().token.Get();
        if (result.HttpResponseMessage.StatusCode != HttpStatusCode.OK)
        {
            MessageBox.Show(result.message.ToString());
        }
        else
        {
            token = result.token;
            off_id = result.officer_id;
            this.Hide();
            Dashboard obj = new Dashboard();
            obj.Show();
        }
    }
    private async void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(txtUser.Text + ":" + txtPassword.Text));
            var client = new RestClient("http://127.0.0.1:5000/api/v1/", new Dictionary<string, string> { { "Authorization", "Basic " + encoded } });
            await getOfficerToken(client);
        }
        catch (Exception ex) 
        {
            connectionlbl.Text = "There is no connection to the server.";
        }
    }
