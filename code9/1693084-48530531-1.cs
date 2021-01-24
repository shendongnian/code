    Class Customer{
         string name;
         string surName;
         public Customer setName(string _name){
             this.name=_name;
             return this;
         }
         public Customer setSurname(string _surName){
             this.surName=_surName;
             return this;
         }
    }
    var customer=new Customer.setName("Hasan").setSurname("Jafarov");
