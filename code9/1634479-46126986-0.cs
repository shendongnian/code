    public override double calculatesalary()
        {
            var salary = base.calculatesalary();
            if (salary <= 10000)
            {
                Deduction = 0.11;
            }
            else if (salary >= 10001 && salary <= 20000)
            {
                Deduction = 0.22;
            }
            else if (salary >= 20001 && salary <= 30000)
            {
                Deduction = 0.34;
            }
            else if (salary >= 30001)
            {
                Deduction = 0.58;
            }
            return salary * Deduction;
        }
