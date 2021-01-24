    public class RolesViewModel
    {
        public Role Role { get; set; }
        public List<Resource> Resources { get; set; }
    }
    var list = ctx.Roles
        .Select(r => new RolesViewModel
        {
            Role = r,
            Resources = r.RolesResources.Select(rr => rr.Resources).ToList()
        })
        .ToList();
