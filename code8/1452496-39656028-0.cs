        public EmploymentType EmpType 
        {
            get
            {
                return empType;
            }
            set
            {
                if (EmploymentType.IsDefined(typeof(EmploymentType), value))
                {
                    empType = value;
                }
                else
                {
                    throw new InvalidEnumArgumentException("Error");
                }
            }
        }
        private EmploymentType empType; 
    
