    using Project.Models.DatabaseModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    
    namespace Project.Data
    {
        public class SeedData
        {
            private ApplicationDbContext _context;
    
            public ApplicationContextSeedData(ApplicationDbContext context)
            {
                _context = context;
            }
            public void EnsureSeedData()
            {
    
                if ("Check if roles are already there")
                {
                    role = new Rol() { Name="Role1", Aciklama="Site Yöneticisi"};
                    roleManager.Create(role);
                    role = new Rol() { Name="Role2", Aciklama="Site Yöneticisi"};
                    roleManager.Create(role);
                    role = new Rol() { Name="Role3", Aciklama="Site Yöneticisi"};
                    roleManager.Create(role);
    
                }
    
            }
    
        }
    }
