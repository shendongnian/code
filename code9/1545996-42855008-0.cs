    public static class MobileServiceLoginExtend
    {
        public static async Task CustomLoginAsync(this MobileServiceClient client, LoginAccount account)
        {
            var jsonResponse = await client.InvokeApiAsync("/.auth/login/custom", JObject.FromObject(account), HttpMethod.Post, null);
            //after successfully logined, construct the MobileServiceUser object with MobileServiceAuthenticationToken
            client.CurrentUser = new MobileServiceUser(jsonResponse["user"]["userId"].ToString());
            client.CurrentUser.MobileServiceAuthenticationToken = jsonResponse.Value<string>("authenticationToken");
            //retrieve custom response parameters
            string customUserName = jsonResponse["user"]["userName"].ToString();
        }
    }
