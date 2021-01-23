    // ICommand is a marker interface, not to be confused with ICommand from WPF
    public class RegisterTenantCommand : ICommand
    {
        public string TenantId { get; set; }
        public string Name { get; set; }
    }
