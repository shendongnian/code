    public class OrganizationLocation : IOrganizationLocation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    
    public interface IOrganizationLocation
    {
        string Name { get; }
    }
    
    public class Organization : IOrganization
    {
        public Guid Id { get; set; }
        public string Alias { get; set; }
    
        public virtual ICollection<OrganizationLocation> Location { get; set; }
    
        public IEnumerable<IOrganizationLocation> Locations => Location
    }
    
    public interface IOrganization
    {
        string Alias { get; }
        IEnumerable<IOrganizationLocation> Locations { get; }
    }
