        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var graphClient = new GraphServiceClient(new DelegateAuthenticationProvider(async requestMessage =>
            {
                var accessToken = await HttpContext.Authentication.GetTokenAsync("access_token");
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", accessToken);
            }));
            var message = new Message
            {
                Subject = "Hello",
                Body = new ItemBody
                {
                    Content = "World",
                    ContentType = BodyType.Text,
                },
                ToRecipients = new[]
                {
                    new Recipient
                    {
                        EmailAddress = new EmailAddress
                        {
                            Address = "email@address.com",
                            Name = "Somebody",
                        }
                    }
                },
            };
            var request = graphClient.Me.SendMail(message, true);
            await request.Request().PostAsync();
            return Ok();
        }
