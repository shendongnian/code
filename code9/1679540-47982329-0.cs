    private List<Payment> _payments = new List<Payment>;
    public IEnumerable<Payment> Payments {
        get => _payments.Where(x => x.IsActive);
    }
    public void AddPayment(Payment pmt) => _payments.Add(pmt);  
