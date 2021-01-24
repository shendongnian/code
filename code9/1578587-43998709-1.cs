    ExecutionOrder test = JsonConvert.DeserializeObject<ExecutionOrder>(jsonText);
    test.Executions.ForEach(delegate(Execution exec)
    {
        Console.WriteLine(test.Usr_id);
        Console.WriteLine(test.Patient_id);
        Console.WriteLine(exec.E_id);
        Console.WriteLine(exec.E_title);
        Console.WriteLine(exec.E_description);
        Console.WriteLine(exec.E_date);
        Console.WriteLine(exec.E_delete);
        Console.WriteLine();
    });
