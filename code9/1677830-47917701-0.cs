    void Main()
    {
    
    	PersonalAccounts PA = new PersonalAccounts("Andy", "Smith", "123 Hope St.", 500M, DateTime.Today, DateTime.Today.AddDays(30));
    
    	Console.WriteLine("Name: " + PA.FirstName + " " + PA.LastName + string.Format(" Amount Due: {0:C2}", PA.AmountDue) + " Due: " + PA.DueDate.ToString("d"));
    
    	BusinessAccounts BA = new BusinessAccounts("Sam's Scooters", "456 Lost Ave.", 700M, DateTime.Today, DateTime.Today.AddDays(60));
    
    	Console.WriteLine("Name: " + BA.BusinessName + " " + string.Format("Amount Due: {0:C2}", BA.AmountDue) + " Due: " + BA.DueDate.ToString("d"));
    
    
    	//I want to reset the Amount Due here, but don't know how.
    	PA.Pay();
    	Console.WriteLine("Name: " + PA.FirstName + " " + PA.LastName + string.Format(" Amount Due: {0:C2}", PA.AmountDue) + " Due: " + PA.DueDate.ToString("d"));
    	BA.Pay();
    	Console.WriteLine("Name: " + BA.BusinessName + " " + string.Format("Amount Due: {0:C2}", BA.AmountDue) + " Due: " + BA.DueDate.ToString("d"));
    
    	Console.ReadLine();
    }
    
    // Define other methods and classes here
    abstract class Account : IPayMyBill
    {
    
    	private String _address;
    	private Decimal _amountDue;
    	private DateTime _invoiceDate;
    
    	public Account(String address, Decimal amountDue, DateTime invoiceDate, DateTime DueDate)
    	{
    		Address = address;
    		AmountDue = amountDue;
    		InvoiceDate = invoiceDate;
    
    	}
    	public String Address
    	{
    		get { return _address; }
    		set { _address = value; }
    	}
    	public Decimal AmountDue
    	{
    		get { return _amountDue; }
    		set { _amountDue = value; }
    	}
    	public DateTime InvoiceDate
    	{
    		get { return _invoiceDate; }
    		set { _invoiceDate = value; }
    	}
    	public abstract DateTime DueDate
    	{
    		get;
    	}
    	public void Pay()
    	{
    		this.AmountDue = 0;
    	}
    }
    
    class PersonalAccounts : Account, IPayMyBill
    {
    	private String _firstName;
    	private String _lastName;
    
    	public PersonalAccounts(String firstName, String lastName, String address, Decimal amountDue, DateTime invoiceDate, DateTime DueDate) : base(address, amountDue, invoiceDate, DueDate)
    	{
    		FirstName = firstName;
    		LastName = lastName;
    	}
    	public String FirstName
    	{
    		get { return _firstName; }
    		set { _firstName = value; }
    	}
    	public String LastName
    	{
    		get { return _lastName; }
    		set { _lastName = value; }
    	}
    	public override DateTime DueDate
    	{
    		get { return DateTime.Today.AddDays(30); }
    	}
    }
    class BusinessAccounts : Account, IPayMyBill
    {
    	private String _businessName;
    
    	public BusinessAccounts(String businessName, String address, Decimal amountDue, DateTime invoiceDate, DateTime DueDate) : base(address, amountDue, invoiceDate, DueDate)
    	{
    		BusinessName = businessName;
    	}
    	public String BusinessName
    	{
    		get { return _businessName; }
    		set { _businessName = value; }
    	}
    	public override DateTime DueDate
    	{
    		get { return DateTime.Today.AddDays(60); }
    	}
    }
    public interface IPayMyBill
    {
    	void Pay();
    }
