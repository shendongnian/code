    public void Override(AutoMapping<Client> mapping)
    {
         mapping.Id(c => c.Id).GeneratedBy.Native();
         mapping.HasMany(c => c.Residences).Inverse().Cascade.All();
         mapping.Table("Clients");
    }
    and
    
    public void Override(AutoMapping<Residence> mapping)
    {
         mapping.Id(p => p.Id);
         mapping.References(x => x.Client)
    }
