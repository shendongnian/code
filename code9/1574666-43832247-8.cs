    public class Developer : Employee
    {
        public new int SalaryWithHiding
        {
            get
            {
                return 50000;
            }
        }
        public override int SalaryWithOverriding
        {
            get
            {
                return 50000;
            }
        }
    }
