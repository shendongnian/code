    using System;
    using System.Data.Entity;
    
    public class SectionRepository
    {
        private readonly _context;
    
    
        public SectionRepository(IMyDbContext context)
        {
            _context = context
        }
    
        public ICollection<SectionName> GetAll()
        {
            return _context.SectionNames
                .Include(sn => sn.SectionsSuffix.SectionLine)
                .Select(sn => sn).ToList();
        }
    }
