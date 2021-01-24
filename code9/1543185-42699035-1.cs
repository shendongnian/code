        HttpClient httpClient = new HttpClient();
        MultipartFormDataContent form = new MultipartFormDataContent();
        form.Add(new StringContent(username), "username");
        form.Add(new StringContent(useremail), "email");
        form.Add(new StringContent(password), "password");            
        form.Add(new ByteArrayContent(imagebytearraystring, 0, imagebytearraystring.Count()), "profile_pic", "hello1.jpg");
        HttpResponseMessage response = await httpClient.PostAsync("PostUrl", form);
