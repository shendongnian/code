    public class TheHub : Hub
    {
        public void RoleChanged(int userId)
        {
            Clients.All.roleChanged(userId);
        }
    }
