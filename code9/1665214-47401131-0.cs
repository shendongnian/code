        public Data.Models.Employee ToEmployee(Data.Models.Position position)
        {
            return new Data.Models.Employee
            {
                Name = Name,
                Surname = Surname,
                Phone = Phone,
                Salary = Salary.HasValue ? Salary.Value : 0,
                Position = position 
            };
        }
