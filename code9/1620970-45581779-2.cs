    button.Click += async delegate
    {
        try {
            result.Text = "Calling Cloud.....";
            var response = await FH.Cloud("hello", "GET", null, new Dictionary<string, string>() { { "hello", input.Text } });
            if (response.Error == null)
            {
                Log.Debug(Tag, "cloudCall - success");
                result.Text = (string)response.GetResponseAsDictionary()["msg"];
            }
            else
            {
                Log.Debug(Tag, "cloudCall - fail");
                Log.Error(Tag, response.Error.Message, response.Error);
                result.Text = response.Error.Message;
            }
        } catch (Exception e) {
            Android.Util.Log.Error("buttonError", e.Message);
        }
    };
