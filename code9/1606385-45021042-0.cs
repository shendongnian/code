        using (var client = new HttpClient())
        {
            var username = "jobusername";
            var password = "jobpassword";
            var byteArray = Encoding.ASCII.GetBytes($"{username}:{password}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            var response = await client.PostAsync("joburl", null);
        }
