    // needs System.Net.Mail for its MailMessage class - but you could write your own
    private void Send(IEnumerable<Customer> customers, string body)
    {
        foreach(Customer customer in customers)
            Send(customer, body);
    }
    private void Send(Customer customer, string body)
    {
        MailMessage message = GenerateMessage(customer, body);
        // your code for sending/retrying; omitted to keep the code short
    }
    private MailMessage GenerateMessage(Customer customer, string body)
    {
        string subject = "...";
        string from = "...";
        string to = customer.Email;
        MailMessage retVal = new MailMessage(from, to, subject, body);
        return retVal;
    }
