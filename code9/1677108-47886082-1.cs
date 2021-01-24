    //Lets take it up a notch and leave behind implementation specifics and fully encapsulate
    //With DI/IoC in mind
    private IBookingService _bookingService;
    public SomeController(IBookingService bookingService;)
    {
        _bookingService = bookingService;
    }
    [HttpPost]
    public async Task<HttpResponseMessage> GetUserBookingsAsync(int userId)
    {
	   return await _bookingService.GetUserBookingsAsync(userId);
    }
