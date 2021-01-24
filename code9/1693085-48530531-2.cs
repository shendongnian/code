    class Customer{
         string name;
         string surName;
         public Customer SetName(string _name){
             this.name=_name;
             return this;
         }
         public Customer SetSurname(string _surName){
             this.surName=_surName;
             return this;
         }
    }
    var customer=new Customer().SetName("Hasan").SetSurname("Jafarov");
