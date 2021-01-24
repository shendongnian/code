    public class Company
    {
        // just add this code block to all your classes that would need to access
        // your function
        public object this[string propertyName] 
        {
            get{
                Type myType = typeof(Company);                   
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                return myPropInfo.GetValue(this, null);
            }
            set{
                Type myType = typeof(Company);                   
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                myPropInfo.SetValue(this, value, null);
            }
    
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyAddress1 { get; set; }
        public string CompanyPostCode { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyCounty { get; set; }
    }
