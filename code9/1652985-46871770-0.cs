    private async void Button1_Click(object sender, EventArgs e)
    {
        await GetRequest();
    }
    private async void Button2_Click(object sender, EventArgs e)
    {
            Person p = new Person(0, nameText.Text);
            JavaScriptSerializer js = new JavaScriptSerializer();
            String jsonPost = js.Serialize(p);
            await PostRequest(jsonPost);
    }
