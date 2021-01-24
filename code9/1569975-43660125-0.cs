    var client = new HttpClient() //if used frequently, don't dispose this guy, make him a singleton if you can (see link below)
          String uname = UserName.Text;
        String pass = Password.Text;
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
         var result = await client.GetAsync("http://localhost:56908/api/vendor/" + uname + "/" + pass);
