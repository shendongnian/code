        [HttpGet]
        public async Task<ActionResult> SignalR()
        {
            dynamic model = new ExpandoObject();
            var hubConnection = new HubConnection("http://sandbox.net");
            var myHub = hubConnection.CreateHubProxy("MyHub");
            myHub.On<string>("addMessage", (user) =>
            {
                model.User = user;
            });
            await hubConnection.Start();
            await myHub.Invoke("Send", "an user");
            return View(model);
        }
