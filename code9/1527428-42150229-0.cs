    public class ReferenceBoolean
    {
          public bool Value{get;set;}
    }
    public class Form1
    {
       protected ReferenceBoolean HalfHourSelectedReference{get;set;}
       public bool HalfHourSelected
       {
          get{return this.HalfHourSelectedReference.Value;}
          set{this.HalfHourSelectedReference.Value = value;}
       }
       public Form1()
       {
           this.HalfHourSelectedReference = new ReferenceBoolean();
       }
    }
    public class Form2
    {
        protected ReferenceBoolean HalfHourSelectedReference{get;set;}
       public bool HalfHourSelected
       {
          get{return this.HalfHourSelectedReference.Value;}
          set{this.HalfHourSelectedReference.Value = value;}
       }
        public Form2(ReferenceBoolean halfHourSelected)
        {
            this.HalfHourSelectedReference = value;
        }
    }
