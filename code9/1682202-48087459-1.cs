    public List<Dado> GetDados()
    {
        var sendFilter = new Filter<MessageSent>();
        //employeeFilter.Add(x => x.Name, name);
        sendFilter.Add(x => x.MessageSentSeq, ID_GROUP_SEND);
        // You can add more filters
    
        MessageSentService svc = new MessageSentService();
        var messages = svc.Find(sendFilter).ToList();
    
        var employees = new EmployeeService().GetAll();
    
        return (
            from employee in employees
            join message in messages
            on employee.EmployeeId equals message.EmployeeId
            select new Dado
            {
                MessageSentId = message.MessageSentId,
                //EmployeeId = message.EmployeeId,
                //MessageSentSeq = message.MessageSentSeq,
                Name = employee.Name,
                Surname = employee.Surname,
                Mobile = employee.Mobile,
                Email = employee.Email,
                Status = "N"
            }
        ).ToList();
    }
