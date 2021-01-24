    public class PaymentList : IEnumerable<Payment>
    {
        private List<Payment> _payments = new List<Payment>();
        public IEnumerator<Payment> GetEnumerator()
        {
            return _payments.Where(p => p.IsActive).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
