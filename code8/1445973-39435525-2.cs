    public class Payments
        {
            public Guid? id { get; set; }
               public Decimal paymentDue { get; set; }
            public DateTime paymentDate { get; set; }
             public bool isinArrears { get; set; }
       
            public Payments(Guid? id, Decimal paymentDue, DateTime paymentDate, 
             bool isinArrears)
            {
                this.id = id;
                 this.paymentDue = paymentDue;
                this.paymentDate = paymentDate;
                  this.isinArrears = isinArrears;
              
            }
    }
