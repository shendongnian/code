    public async Task<string> AddUser(string accessToken, string displayName)
    {            
            try
            {
                HttpClient client = new HttpClient();
                var user = new User
                {
                    accountEnabled = true,
                    displayName = displayName,
                    mailNickname = displayName,
                    passwordProfile = new PasswordProfile
                    {
                        password = "asdf123(",
                        forceChangePasswordNextLogin = false
                    },
                    userPrincipalName = $"{displayName}@adfei3.onmicrosoft.com"
                };
               
                var bodyContent = new StringContent(new JavaScriptSerializer().Serialize(user), Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", accessToken);
                HttpResponseMessage responseMessage = await client.PostAsync(addUserRequestUri, bodyContent);
                var responseString = await responseMessage.Content.ReadAsStringAsync();
                var objectId = JObject.Parse(responseString)["objectId"].Value<string>();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"OK:{displayName}|Task{Thread.CurrentThread.ManagedThreadId}");
                return objectId;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Failed:{displayName}|Task{Thread.CurrentThread.ManagedThreadId}");
                return "";
            }
    }
    public async Task AddMember(string accessToken, string groupId, string objectId)
    {
            if (string.IsNullOrEmpty(objectId))
                return;
            try
            {
                HttpClient client = new HttpClient();
                var bodyContent = new StringContent(String.Format("{{\"url\": \"https://graph.windows.net/adfei3.onmicrosoft.com/directoryObjects/{0}\"}}", objectId), Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", accessToken);
                Uri addMemberRequestUri = new Uri(String.Format(addMemberRequestString, groupId));
                HttpResponseMessage responseMessage = await client.PostAsync(addMemberRequestUri, bodyContent);
                if (responseMessage.StatusCode == System.Net.HttpStatusCode.NoContent)
                //return new MemberInfo { GroupId = groupId, UserInfo = userInfo, OK = true };
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"OK:{objectId}|Task{Thread.CurrentThread.ManagedThreadId}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Failed:{objectId}|Task{Thread.CurrentThread.ManagedThreadId}");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Failed:{objectId}|Task{Thread.CurrentThread.ManagedThreadId}");
            }
    }
    public void Test()
    {
            DateTime beginTime = DateTime.Now;
            string accessToken = "";
            string groupId = "92374923-09a2-4e74-a3f2-57bbbafacc8b";
            Parallel.ForEach(Enumerable.Range(1, 200),  i =>
            {
                 AddUser(accessToken, "users" + i).ContinueWith(userId =>
                {
                    AddMember(accessToken, groupId, userId.Result).ContinueWith(a=> {                     
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Total time:{ DateTime.Now.Subtract(beginTime)}");
                    });
                });
            });
    }
