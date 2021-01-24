    public static class PaymentQueryExtensions {
    
        public static IEnumerable<Payment> ApplyNotCancelledFilter(
            this IEnumerable<Payment> payments) {
            
            // no explicit 'join' needed to access properties of base class in EF Model
            return payments.Where(p => p.Cancelled.Equals("0"));
        }
    
        public static IEnumerable<Payment> ApplyTimeFilter(
            this IEnumerable<Payment> payments, DateTime startTime, DateTime endTime) {
            
            return payments.Where(p => p.TimeStamp.CompareTo(startTime) > 0 
                                    && p.TimeStamp.CompareTo(endTime) < 1);
        }
    }
