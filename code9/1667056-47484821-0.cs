        public void SendUserList(List<string> users)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<UserActivityHub>();
            context.Clients.All.updateUserList(users);
        }
