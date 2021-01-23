    public class Service 
    {
        public virtual event System.EventHandler<EventArgs> BeforeSavingRecord;
        public virtual void OnBeforeSavingRecord(object sender, EventArgs e)
        {
            Console.WriteLine("Base: OnBeforeSavingRecord method call");
        }
        public virtual void Create(object item)
        {
            Console.WriteLine("Base: Create method call");
            // this will call the method of the derived class! if you call it from an instance of the derived class
            OnBeforeSavingRecord(this, new EventArgs());
        }
    }
    public partial class BankBusiness : Service
    {
        public override void OnBeforeSavingRecord(object sender, EventArgs e)
        {
            //Do something with entity item before saving
            Console.WriteLine("Derived Class OnBeforeSavingRecord CALL");
            base.OnBeforeSavingRecord(sender, e);                
        }
    }
    static void Main(string[] args)
    {        
        BankBusiness bankBiz = new BankBusiness();
        bankBiz.Create(new object());
        Console.ReadKey();
    }
