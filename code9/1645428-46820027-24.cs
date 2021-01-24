    [Route("Dates/{number}")]
    public IHttpActionResult Get_DateRanges(int number)
    {
        var response = DateRepository.GetDates(number);
        return Json(response);
    }
