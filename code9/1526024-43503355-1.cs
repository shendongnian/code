    MyCodeActivity myCodeActivity = new MyCodeActivity();
    
    var arguments = new Dictionary<String, Object>
    {
        { "Message",  msg },
        { "Entrada",  dtb },
    };
    
    dtb = WorkflowInvoker.Invoke<DataTable>(myCodeActivity, arguments);
