    public AppointmentHandlers AppointmentHandlers { get; set; }
    public object Any(MyRequest request)
    {
         var dep = AppointmentHandlers.AppointmentHandler1();
    }
