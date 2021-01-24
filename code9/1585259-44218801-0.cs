        // need create domain type for keep order information
        // if need you can implement INotifyPropertyChanged
        public class Order {
                int      OrderID {get;set}
                DateTime Date {get;set}
                string   Customer_Name {get;set}
                int      Quality {get;set}
                string   Color {get;set}
                string   PCs       {get;set}
                string   Cutting {get;set}
                decimal  TotalYards {get;set}
        }
        
        // add property inside your form or viewmodel which is source for your form 
        private Order _currentOrder;
        public Order CurrentOrder
        {
            get{ return _currentOrder ;}
            set {
                if (_currentOrder!=value)
                {           
                     FillOrderDetailsBy(_currentOrder.Id)
                }
            }
        }
        
        // implement FillOrderDetails (
        void FillOrderDetails(int orderId)
        {
           var cmd = new SqlCommand(@"Select * from details", conn)
           var reader = cmd.ExecuteReader()
        
           while (reader.Read())
           {
                // add records to your dataTable which is sour
           }  
        }
        
        // change your newOrder button click handler
        void bntNewOrder_Click(sender, ars)
        {
             CurrentOrder = new Order(); // it will clear your dataGrid
        }
    
        // in case if in your domain you implmenet INotifyPropertyChanged
        // you can bind you controls to property of this class
        // this give you fill the power of WinForms dataBinding :))
        // for example in your constructor (after line with InitializeComponents())
        public YourFormName()
       {
        InitializeComponents();
    
        TxtBox_OrderID.DataBindings.Add("Text", CurrentOrder, "OrderID");
        dateTimePicker1.DataBindings.Add("Value", CurrentOrder, "Date");
        // etc with all controls which are related to Order
       } 
 
