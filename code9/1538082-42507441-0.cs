            var hub = GlobalHost.ConnectionManager.GetHubContext<Hubs.MyHub1>();
            //you don't actually have access to the MyHub1 class at this point
            // instead of
            // hub.Clients.All.Message(data.apaAja);
            // you need
            hub.Clients.All.messageSend(data.apaAja);
