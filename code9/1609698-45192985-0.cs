    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    public class MyDbContext : DbContext
    {
        // ...
        public MyDbContext()
        {
            this.GetService<ILocalViewListener>()?.RegisterView(OnStateManagerChanged);
        }
    
        void OnStateManagerChanged(InternalEntityEntry entry, EntityState previousState)
        {
            if (previousState == EntityState.Detached && entry.EntityState == EntityState.Unchanged)
            {
                // Process loaded entity
            }
        }
    }
