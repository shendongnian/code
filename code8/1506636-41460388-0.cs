    using(IEnumerator<Employee> empEnumerator = employeeList.GetEnumerator())
    {
        while(empEnumerator.MoveNext())
        {
            // now empEnumerator.Current is the Employee instance without casting
            Employee emp = empEnumerator.Current;
            string empName = emp.Name;  // ...
        }
    }
