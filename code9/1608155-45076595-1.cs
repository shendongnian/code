    public async void myButton_Click(object sender, EventArguments arg)
    {
        var client=new HttpClient();
        ....
        var result=await client.GetStringAsync(someUrl);
        txtBox1.Text=result;
    }
