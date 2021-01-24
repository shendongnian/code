[Route("/api/webhooks"), AllowAnonymous]
public class WebhooksController : Controller
{
    // POST: /api/webhooks/handle_ams_jobchanged
    [HttpPost("handle_ams_jobchanged")] // <-- Must be an HTTP POST action
    public IActionResult ProcessAMSEvent(
        [FromBody]EventGridEvent[] ev, // 1. Bind the request
        [FromServices]ILogger<WebhooksController> logger)
    {
        var amsEvent = ev.FirstOrDefault(); // TODO: handle all of them!
        if(amsEvent == null) return BadRequest();
        
        // 2. Check the eventType field
        if (amsEvent.EventType == EventTypes.MediaJobStateChangeEvent)
        {
            // 3. Cast the data to the expected type
            var data = (amsEvent.Data as JObject).ToObject<MediaJobStateChangeEventData>();
            
            // TODO: do your thing; eg:
            logger.LogInformation(JsonConvert.SerializeObject(data, Formatting.Indented));
        }
        
        // 4. Respond with a SubscriptionValidationResponse to complete the 
        // event subscription handshake.
        if(amsEvent.EventType == EventTypes.EventGridSubscriptionValidationEvent)
        {
            var data = (amsEvent.Data as JObject).ToObject<SubscriptionValidationEventData>();
            var response = new SubscriptionValidationResponse(data.ValidationCode);
            return Ok(response);
        }
        return BadRequest();
    }
}
