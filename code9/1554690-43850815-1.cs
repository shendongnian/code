     var function = builder.Action("AppointmentsForUsers");
            function.ReturnsCollectionFromEntitySet<AppointmentDTO>("Appointments");
            function.Parameter<ModelWithDatesAndUsers >("Model");
    public class ModelWithDatesAndUsers
    {
        Date fromDate;
        Date toDate;
        Enumerable[int] userIds;
    }
    public async Task<IHttpActionResult> AppointmentsForUsers(ODataActionParameters parameters) 
    {
             ModelWithDateAndUsers model= (ModelWithDatesAndUsers)parameters["Model"];        
    }
