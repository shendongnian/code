    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace CMS  // Your Project Namespace
    {
        public partial class CMSEntities : DbContext
        {
            public CMSEntities(string connectionString)
                : base(connectionString)
            {
            }
        }
    }
