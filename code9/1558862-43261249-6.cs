    public static class PaymentQueryExtensions {
    
        public static IQueryable<T> ApplyNotCancelledFilter(
            this IQueryable<T> payments) 
            where T : BaseTable {
            
            // no explicit 'join' needed to access properties of base class in EF Model
            return payments.Where(p => p.Cancelled.Equals("0"));
        }
    
        public static IQueryable<T> ApplyTimeFilter(
            this IQueryable<T> payments, DateTime startTime, DateTime endTime) 
            where T: BaseTable {
            
            return payments.Where(p => p.TimeStamp.CompareTo(startTime) > 0 
                                    && p.TimeStamp.CompareTo(endTime) < 1);
        }
        public static IGrouping<Typ, T> GroupByType(
             this IQueryable<T> payments) 
             where T: BaseTable {
        
            // assuming the relationship Payment -> Typ has been set up with a backlink property Payment.Typ
            // e.g. for EF fluent API: 
            //  ModelBuilder.Entity<Typ>().HasMany(t => t.Payment).WithRequired(p => p.Typ);
            return payments.GroupBy(p => p.Typ);
        }
    }
