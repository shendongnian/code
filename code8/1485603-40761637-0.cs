    [Route("{username}/{startDate}/{endDate}")]
    [HttpGet]
    public IHttpActionResult BulkTrackEventsByDateRange(string username, string startDate, string endDate)
    {
        BulkEventTrackingResultModel bulkTrackingEventResult = null;
        try
        {
            bulkTrackingEventResult = _bulkTrackingByDateRange.GetBulkTrackingEvents(username, startDate, endDate);
            if (string.IsNullOrWhiteSpace(bulkTrackingEventResult.NoRecordFound))
            {
                return Ok(bulkTrackingEventResult.BulkEventTracking);
            }
            else
            {
                //return Content(HttpStatusCode.NotFound, "Some Message");
                return NotFound("Some Message"); // <--Change to this
            }
        }
        catch (Exception ex)
        {
            return new ResponseMessageResult(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Some Message"));
        }
    }
