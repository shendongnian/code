        [Command("userinfo")]
        public async Task UserInfo(SocketUser user = null)
        {
            if (user == null)
            {
                user = Context.User;
            }
            ...
        }
