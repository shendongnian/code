    public class BaseClass
    {
        public string Field1 { get; set; }
    }
    
    public class DerivedClass: BaseClass
    {
        public string Field2 { get; set; }
    }
    
    public class BaseClassDTO{
        public string Field1 { get; set; }
        public BaseClassDTO(BaseClass baseClass){
            this.Field1 = baseClass.Field1;
        }
    }
