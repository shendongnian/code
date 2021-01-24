    static void Main(string[] args)
    {
        DataTable resultsSystemA;
        DataTable resultsSystemB;
        DataTable resultsSystemC;
        Employee e = new Employee();    
        var a = Task.Run(() => { resultsSystemA = e.EmployeeSearch_SystemA(); });
        var b = Task.Run(() => { resultsSystemB = e.EmployeeSearch_SystemB(); });
        var c = Task.Run(() => { resultsSystemC = e.EmployeeSearch_SystemC(); });
    
        Task.WaitAll(a, b, c);
    
        // use the datatables.
    }
