     public class SimpleClass
    {
        public string myProp { get; set; }
        public SimpleClass()
        {
            this.myProp = "";
        }
        private string Method1()
        {
            this.myProp += "Method1";
            return Method2();
         
        }
        private string Method2()
        {
          return  this.myProp += "Method2";
            
        }
        public string GetProp()
        {
            Method1();
            return this.myProp;
        }
    }
