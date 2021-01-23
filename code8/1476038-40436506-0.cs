    public EmployeeInformation HireEmployee(string name, string job, string promotion, int salary, int productivity)
        {
        Console.WriteLine("==HIRE PEOPLE==");
        EmployeeInformation employeeInformation = new EmployeeInformation(name, job, promotion, salary, productivity);
        Employee[EmployeeAmount] = employeeInformation;
        EmployeeAmount++;
        return employeeInformation;
        }
