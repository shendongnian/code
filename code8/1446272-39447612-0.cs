    class Running
    {
        public Dog RunDog()
        {
            var dogParams = GetParams();
            return DogMethod(dogParams);
        }
    
        public Employee RunEmployee()
        {
            var dogParams = GetParams();
            var employeeParams = ConvertParams(dogParams);
            return EmployeeMethod(employeeParams);
        }
        private DogParams GetParams()
        {
              // a LOT of business logic
        }
    }
