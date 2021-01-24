    public Schedule 
    {
        private List<Payment> _payments;
        public Schedule() 
        {
            _payments = new List<Payment>();
        }
        public IEnumerable<Payment> GetActivePayments()
        {
            //Do whatever you want here, e.g....
            return _payments.Where(x => x.IsActive).ToList();
        }
        public void AddPayment(Payment payment)
        {
            //Do whatever you want here, e.g....
            _payments.Add(payment);
        }
        public void ClearPayments()
        {
            //Do whatever you want here, e.g....
            _payments.Clear();
        }
    }
