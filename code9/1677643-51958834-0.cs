    using Microsoft.EntityFrameworkCore;
    
    namespace ApiWebApplication.Utils
    {
        public static class MyExtensions 
        {
            public static IQueryable<object> Set (this DbContext _context, Type t)
            {
                return (IQueryable<object>)_context.GetType().GetMethod("Set").MakeGenericMethod(t).Invoke(_context, null);
            }
        }
    }
