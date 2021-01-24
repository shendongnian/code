    //Blocking
    public void OrderForm_Load()
    {
        var t1 = new ServiceTask();
        Task.Run(() => t1.PersistTask()); //Approach 1
        //[OR]            
        t1.PersistTask(); //Approach 2
        Console.WriteLine("Second");
    }
