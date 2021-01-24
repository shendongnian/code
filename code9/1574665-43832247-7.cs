    public abstract class Employee
    {
        public int SalaryWithHiding
        {
            get
            {
                return 10000;
            }
        }
        
        public virtual int SalaryWithOverriding
        {
            get
            {
                return 10000;
            }
        }
    }
