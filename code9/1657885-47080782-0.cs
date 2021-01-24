    public class RoleCoordinator
    {
        public event EventHandler<RoleChangedEventArgs> RoleChanged;
        public void RaiseRoleChanged(object sender, Role role)
        {
            RoleChanged?.Invoke(sender, new RoleChangedEventArgs(role));
        }
    }
    public class RoleChangedEventArgs : EventArgs
    {
        public RoleChangedEventArgs(Role role)
        {
            Role = role;
        }
        public Role Role { get; set; }
    }
