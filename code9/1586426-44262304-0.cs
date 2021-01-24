    public bool Load(string employeesFile)
        {
            bool isLoaded = false;
            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader("employees.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    //Splitting the data using |
                    string[] temp = line.Split('|');
                    int year = Convert.ToInt32(temp[5]);
                    int month = Convert.ToInt32(temp[6]);
                    int day = Convert.ToInt32(temp[7]);
                    //Populating the employees details 
                    decimal _salary;
                    if (Decimal.TryParse(temp[8], out _salary))
                    {
                        SalariedEmployee emp = new SalariedEmployee(firstName: temp[1],
                            lastName: temp[0],
                            address: temp[2],
                            postCode: temp[3],
                            phoneNumber: temp[4],
                            dateOfBirth: new DateTime(year, month, day),
                            salary: _salary)
