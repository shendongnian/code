           protected static new Employee LoadReader(IDataRecord dr)
            {
                Employee e = null;
        
                if (dr != null)
                {
                    e = new Employee
                    {
                        FullName = dr.IsDBNull(dr.GetOrdinal("FullName")) ? "" : dr.GetString(dr.GetOrdinal("FullName")),
                        Age = dr.IsDBNull(dr.GetInt32("Age")) ? 0 : dr.GetInt32(dr.GetOrdinal("Age"))
                    };
                       e.PhoneNumber = LoadPhoneNumbers(e);
                }
                return e;
            }
    
     protected void LoadPhoneNumbers(Employee employee){
    
         * Do a read to the database passing the employee id
         * You will receive a reader, this has all your phone number records
         * for each record do
         employee.PhoneNumbers.Add(the phone number)
    
    }
